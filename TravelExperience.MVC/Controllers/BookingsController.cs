﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;

namespace TravelExperience.MVC.Controllers
{
    [AllowAnonymous]
    public class BookingsController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        private readonly IUnitOfWork _unitOfWork;

        public BookingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = _unitOfWork.Bookings.GetAll();
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
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.AccommodationID = new SelectList(_unitOfWork.Accommodations.GetAll(), "AccommodationID", "Title");
            ViewBag.ExperienceID = new SelectList(_unitOfWork.Experiences.GetAll(), "ExperienceID", "Title");
            ViewBag.UserId = new SelectList(_unitOfWork.Users.GetAll(), "Id", "FirstName");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingID,Price,UserId,AccommodationID,ExperienceID,BookingStartDate,BookingEndDate,CreationDate")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Bookings.Create(booking);
                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }

            ViewBag.AccommodationID = new SelectList(_unitOfWork.Accommodations.GetAll(), "AccommodationID", "Title", booking.AccommodationID);
            ViewBag.ExperienceID = new SelectList(_unitOfWork.Experiences.GetAll(), "ExperienceID", "Title", booking.ExperienceID);
            ViewBag.UserId = new SelectList(_unitOfWork.Users.GetAll(), "Id", "FirstName", booking.UserId);

            return View(booking);
        }

        //// GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = _unitOfWork.Bookings.GetById(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccommodationID = new SelectList(_unitOfWork.Accommodations.GetAll(), "AccommodationID", "Title", booking.AccommodationID);
            ViewBag.ExperienceID = new SelectList(_unitOfWork.Experiences.GetAll(), "ExperienceID", "Title", booking.ExperienceID);
            ViewBag.UserId = new SelectList(_unitOfWork.Users.GetAll(), "Id", "FirstName", booking.UserId);
            return View(booking);
        }

        //// POST: Bookings/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Booking booking)
        {
            if (ModelState.IsValid)
            {
                //_unitOfWork.Entry(booking).State = EntityState.Modified; // dont remember that 
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            ViewBag.AccommodationID = new SelectList(_unitOfWork.Accommodations.GetAll(), "AccommodationID", "Title", booking.AccommodationID);
            ViewBag.ExperienceID = new SelectList(_unitOfWork.Experiences.GetAll(), "ExperienceID", "Title", booking.ExperienceID);
            ViewBag.UserId = new SelectList(_unitOfWork.Users.GetAll(), "Id", "FirstName", booking.UserId);
            return View(booking);
        }

        //// GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = _unitOfWork.Bookings.GetById(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        //// POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.Bookings.Delete(id);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
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