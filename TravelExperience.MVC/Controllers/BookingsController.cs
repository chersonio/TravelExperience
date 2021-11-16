using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.DataAccess.Persistence;
using TravelExperience.MVC.ViewModels;

namespace TravelExperience.MVC.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = _unitOfWork.Bookings.GetAll(); // do we need to make the Includes here?

            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Booking booking = _unitOfWork.Bookings.GetById(id);

            if (booking == null)
                return HttpNotFound();

            // TODO: MAYBE WHEN WE SET THE USER IDENTITY WE WILL ADD HERE THE AUTHENTICATION

            return View(booking);
        }

        // GET: Bookings/Create
        [Authorize]
        public ActionResult Create()
        {
            var hostID = User.Identity.GetUserId();

            var viewModel = new BookingViewModel() // TODO: need to have clear thought about the HOST.
            {
                HostID = hostID,
                Accommodations = _unitOfWork.Accommodations.GetAll(),
                Experiences = _unitOfWork.Experiences.GetAll(),
            };

            //ViewBag.AccommodationID = new SelectList(db.Accomodations, "AccommodationID", "Title");
            //ViewBag.ExperienceID = new SelectList(db.Experiences, "ExperienceID", "Title");
            //ViewBag.TravelerID = new SelectList(db.Travelers, "TravelerID", "FirstName");

            return View(viewModel);
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Booking booking) // NEED TO KNOW ABOUT THE PAGES UTILIZATION. WHAT DOES FRONT NEED? 
        {
            if (ModelState.IsValid)
            {
                //db.Bookings.Add(booking);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.AccommodationID = new SelectList(db.Accomodations, "AccommodationID", "Title", booking.AccommodationID);
            //ViewBag.ExperienceID = new SelectList(db.Experiences, "ExperienceID", "Title", booking.ExperienceID);
            //ViewBag.TravelerID = new SelectList(db.Travelers, "TravelerID", "FirstName", booking.TravelerID);

            var hostID = User.Identity.GetUserId();

            var viewModel = new BookingViewModel() // TODO: need to have clear though about the HOST.
            {
                HostID = hostID,
                Accommodations = _unitOfWork.Accommodations.GetAll(),
                Experiences = _unitOfWork.Experiences.GetAll(),
            };

            _unitOfWork.Bookings.Create(booking);
            _unitOfWork.Complete();

            return View(viewModel); // NEED TO CHECK THE PAGE'S NEEDS
        }

        // GET: Bookings/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // MPERDEMA ME USERID POU THELEI STRING KAI POIOS EINAI O HOST POU ZITAEI KAI GAMATA OLA!!!!

            Booking booking = _unitOfWork.Bookings.GetById(id); //

            if (booking == null)
            {
                return HttpNotFound();
            }

            if (booking.HostID.ToString() != User.Identity.GetUserId()) // *** UserID needs string.
                return new HttpUnauthorizedResult();

            var viewModel = new BookingViewModel() // TODO: need to have clear thought about the HOST.
            {
                HostID = booking.HostID.ToString(),
                Accommodations = _unitOfWork.Accommodations.GetAll(),
                Experiences = _unitOfWork.Experiences.GetAll(),
                //Travelers = _unitOfWork.Travelers.GetAll().Where(x => _unitOfWork.Bookings.GetAll().Contains(x.)) // TOUS TRAVELERS PWS THA TOUS TSIMPAEI?
            };

            //ViewBag.AccommodationID = new SelectList(db.Accomodations, "AccommodationID", "Title", booking.AccommodationID);
            //ViewBag.ExperienceID = new SelectList(db.Experiences, "ExperienceID", "Title", booking.ExperienceID);
            //ViewBag.TravelerID = new SelectList(db.Travelers, "TravelerID", "FirstName", booking.TravelerID);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingID,Price,HostID,TravelerID,AccommodationID,ExperienceID,BookingStartDate,BookingEndDate")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccommodationID = new SelectList(db.Accommodations, "AccommodationID", "Title", booking.AccommodationID);
            ViewBag.ExperienceID = new SelectList(db.Experiences, "ExperienceID", "Title", booking.ExperienceID);
            ViewBag.TravelerID = new SelectList(db.Travelers, "TravelerID", "FirstName", booking.TravelerID);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
