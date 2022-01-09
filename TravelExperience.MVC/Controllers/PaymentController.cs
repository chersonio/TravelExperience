using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.DataAccess.Persistence;
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
            // amount in wallet
            // booking details (formInput+ necessary accommodation info)
            // confirmationPage -> HttpGet => new Booking to Bookings Controller 
            // need to view this booking from BookingController

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
                    // einai ontws lathos. na doume to basiko
                    return Index(bookingConfirmationDto); // wrong na tsekarw an pxianei // den pxianei giati psaxnei tin epomeni forma.. prepei na ginei cancel "reset"


                // TODO:
                // prepei na ginei query gia inuvailable dates auto vgainei apo:
                // ta !available dates tou accommodation ( meria host )
                // ta booking dates tou sygkekrimenou accommodation.

                // ta booking dates mporoun na mpoun pleon sti function pou eftiaksa sto index

                // prepei na ginei error page handling

                // genika gia ta 404 kai genikevmena errors

                // tha prepei na checkarei an o xristis paei na kleisei diko tou booking kai na min ton afinei

                // na dimiourgei neo wallet gia neo xristi

                // Yparxei ena bug otan kanei neo register deixnei lathos query sto dashboard kai den deixnei 

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
                    var hostWallet = _unitOfWork.Users.GetWalletOfUserFromUserID(accom.HostID); // get 
                    var travelerWallet = _unitOfWork.Users.GetWalletOfUserFromUserID(booking.UserId); // userid

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
                    else
                    {
                        // TH PATHSES MOUSKARE!!!
                        // IOU IOU ERROR ERROR WOOOEEEE WOOOEEE AWOO AWOO
                    }

                    _unitOfWork.Transactions.Create(transaction);
                    _unitOfWork.Complete();
                }
                catch (Exception ex)
                {
                    // an error occured.
                    // go to another view.
                    // inform user
                    return View("OopsSomethingWrongWithPayment", ex);
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

        //// GET: Payment/Details/5
        //public ActionResult Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Transaction transaction = _unitOfWork.Transactions.Find(id);
        //    if (transaction == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(transaction);
        //}

        //// GET: Payment/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Payment/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "TransactionID,TimeStamp,SendingWalletID,ReceivingWalletID,BookingID,Amount")] Transaction transaction)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        transaction.TransactionID = Guid.NewGuid();
        //        db.Transactions.Add(transaction);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(transaction);
        //}

        //// GET: Payment/Edit/5
        //public ActionResult Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Transaction transaction = db.Transactions.Find(id);
        //    if (transaction == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(transaction);
        //}

        //// POST: Payment/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "TransactionID,TimeStamp,SendingWalletID,ReceivingWalletID,BookingID,Amount")] Transaction transaction)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(transaction).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(transaction);
        //}

        //// GET: Payment/Delete/5
        //public ActionResult Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Transaction transaction = db.Transactions.Find(id);
        //    if (transaction == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(transaction);
        //}

        //// POST: Payment/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Guid id)
        //{
        //    Transaction transaction = db.Transactions.Find(id);
        //    db.Transactions.Remove(transaction);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
