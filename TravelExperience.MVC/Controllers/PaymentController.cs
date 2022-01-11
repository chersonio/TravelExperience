using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.DTO.Dtos;
using TravelExperience.MVC.ViewModels;

namespace TravelExperience.MVC.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Payment
        public ActionResult Index(BookingConfirmationDto bookingConfirmationDto)
        {
            if (bookingConfirmationDto.BookingEndDate < bookingConfirmationDto.BookingStartDate)
                return View("Error");

            var travelerID = User.Identity.GetUserId();

            var wallet = _unitOfWork.Users.GetWalletOfUserFromUserID(travelerID);

            var viewModel = new PaymentViewModel();
            var accom = _unitOfWork.Accommodations.GetById(bookingConfirmationDto.AccommodationID);

            if (accom == null)
                return HttpNotFound();

            // Validations
            var totalDays = (bookingConfirmationDto.BookingEndDate - bookingConfirmationDto.BookingStartDate).Days;
            viewModel.TotalPaymentAmount = accom.PricePerNight * totalDays;
            viewModel.WalletAmount = wallet.Amount;
            viewModel.AccommodationTitle = accom.Title;
            viewModel.AccommodationID = accom.AccommodationID;
            viewModel.BookingStartDate = bookingConfirmationDto.BookingStartDate.ToShortDateString();
            viewModel.BookingEndDate = bookingConfirmationDto.BookingEndDate.ToShortDateString();
            viewModel.Guests = bookingConfirmationDto.Guests;
            viewModel.Traveler = _unitOfWork.Users.GetById(travelerID);

            return View("Index", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValidateNewPayment(BookingConfirmationDto bookingConfirmationDto)
        {

            var booking = new Booking();
            if (bookingConfirmationDto.Confirmed)
            {
                // Checks if dates are valid
                if (bookingConfirmationDto.BookingStartDate < DateTime.Now.Date ||
                    bookingConfirmationDto.BookingEndDate < bookingConfirmationDto.BookingStartDate)
                {
                    bookingConfirmationDto.Confirmed = false;
                    return Index(bookingConfirmationDto);
                }

                booking.AccommodationID = bookingConfirmationDto.AccommodationID;
                booking.BookingStartDate = bookingConfirmationDto.BookingStartDate;
                booking.BookingEndDate = bookingConfirmationDto.BookingEndDate;

                booking.Email = bookingConfirmationDto.Email;
                booking.PhoneNumber = bookingConfirmationDto.PhoneNumber;

                var travelerID = User.Identity.GetUserId();
                booking.UserId = travelerID;

                var accom = _unitOfWork.Accommodations.GetById(booking.AccommodationID);

                if (accom == null)
                    return HttpNotFound();

                var totalDays = (bookingConfirmationDto.BookingEndDate - bookingConfirmationDto.BookingStartDate).Days;
                booking.Price = accom.PricePerNight * totalDays;

                var transaction = new Transaction();

                try
                {
                    var hostWallet = _unitOfWork.Users.GetWalletOfUserFromUserID(accom.HostID);
                    var travelerWallet = _unitOfWork.Users.GetWalletOfUserFromUserID(booking.UserId);

                    transaction.ReceivingWalletID = hostWallet.WalletID;
                    transaction.SendingWalletID = travelerWallet.WalletID;

                    transaction.Amount = booking.Price;
                    if (travelerWallet.Amount >= booking.Price)
                    {
                        hostWallet.Amount += transaction.Amount;
                        travelerWallet.Amount -= transaction.Amount;

                        _unitOfWork.Bookings.Create(booking);
                        _unitOfWork.Complete();

                        transaction.BookingID = booking.BookingID;
                    }

                    _unitOfWork.Transactions.Create(transaction);
                    _unitOfWork.Complete();
                }
                catch (Exception ex)
                {
                    return View("Error", ex);
                }
                var transactionViewModel = new TransactionViewModel()
                {
                    BookingID = booking.BookingID,
                    BookingStartDate = booking.BookingStartDate.ToShortDateString(),
                    Location = accom.Location,
                    Host = accom.Host,
                    Traveler = booking.User
                };
                return View("Success", transactionViewModel); // payment done view
            }
            return Index(bookingConfirmationDto); // wrong na tsekarw an pxianei
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
