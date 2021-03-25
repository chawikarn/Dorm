using DormitoryWeb.Models;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Net;
using System.Data.Entity;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Web.DynamicData;


namespace DormitoryWeb.Controllers
{
    public class BookingController : Controller
    {
        private Entities8 db = new Entities8();

        // GET: Booking


        public ActionResult Index()
        {
            if (User.Identity.Name == "admin@mail.com")
            {
                return View(db.booking);
            }
            else
            {
                var result = from b in db.booking
                             join a in db.AspNetUsers
                             on b.customer_id equals a.Id
                             where a.UserName == User.Identity.Name
                             select b;

                return View(result);
            }
        }



        // GET: Booking/Details/5
        public ActionResult Details(int? id)
        {
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
        }

        // GET: Booking/Create
        public ActionResult Create()
        {

            var roomModel = new booking();
            roomModel.roomlist = from r in db.Room
                                 where r.status == "Available"
                                 select r;
            return View(roomModel);

        }

        // POST: Booking/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "booking_id,customer_id,room_id,date_in,File,status,Email")] booking booking)
        {
            var file = Request.Files[0];
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath(" ~/Content/contract/"), fileName);
                file.SaveAs(path);
                booking.File = fileName;
            }


            try
            {
                // TODO: Add insert logic here
                ViewBag.roomlist = new SelectList(db.booking, "room_id");
                booking.status = "not verified";
                booking.customer_id = User.Identity.GetUserId();
                booking.Email = User.Identity.GetUserName();
                db.booking.Add(booking);
                db.SaveChanges();
                return View("Success");
            }
            catch
            {

                return View(booking);
            }
        }

        // GET: Booking/Edit/5
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

        // POST: Booking/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "booking_id, customer_id, room_id, date_in,File,status,Email")] booking bookings)
        {
            if (User.Identity.Name != "admin@mail.com")
            {
                var file = Request.Files[null];
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath(" ~/Content/contract/"), fileName);
                    file.SaveAs(path);
                    bookings.File = fileName;
                }
            }

            db.Entry(bookings).State = EntityState.Modified;
            db.Entry(bookings).Property(x => x.booking_id).IsModified = false; //keep data not modified
            db.Entry(bookings).Property(x => x.customer_id).IsModified = false;
            db.Entry(bookings).Property(x => x.date_in).IsModified = false;
            db.Entry(bookings).Property(x => x.status).IsModified = false;
            db.Entry(bookings).Property(x => x.Email).IsModified = false;
            db.booking.Add(bookings);
            db.SaveChanges();
            return View("AddcontractSuccess");
        }

        // GET: Booking/Delete/5
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
