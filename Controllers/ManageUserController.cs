using DormitoryWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DormitoryWeb.Controllers
{
    public class ManageUserController : Controller
    {
        // GET: ManageUser
        private Entities8 db = new Entities8();
        public ActionResult Index()
        {
                return View(db.booking);
        }

        // GET: ManageUser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking bookings = db.booking.Find(id);
            if (bookings == null)
            {
                return HttpNotFound();
            }
            return View(bookings);
        }

        // GET: ManageUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageUser/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManageUser/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking bookings = db.booking.Find(id);
            if (bookings == null)
            {
                return HttpNotFound();
            }
            return View(bookings);
        }

        // POST: ManageUser/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "booking_id, customer_id, room_id, date_in,File,status")] booking bookings,Room rooms)
        {
            try
            {
                // TODO: Add update logic here
                if (bookings.status == "verified")
                {
                    rooms.status = "Not Available";

                }
                else if (bookings.status == "not verified")
                {
                    rooms.status = "Available";
                }
                db.Entry(bookings).State = EntityState.Modified;
                db.Entry(rooms).State = EntityState.Modified;
                db.Entry(rooms).Property(x => x.type_id).IsModified = false; //keep data not modified
                db.Entry(rooms).Property(x => x.Room_info).IsModified = false;
                db.Entry(rooms).Property(x => x.url).IsModified = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(db.booking);
            }
        }

        // GET: ManageUser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking bookings = db.booking.Find(id);
            if (bookings == null)
            {
                return HttpNotFound();
            }
            return View(bookings);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            booking bookings = db.booking.Find(id);
            db.booking.Remove(bookings);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Contract/"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}
