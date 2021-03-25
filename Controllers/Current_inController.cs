using DormitoryWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DormitoryWeb.Controllers
{
    public class Current_inController : Controller
    {

        private Entities8 db = new Entities8();
        // GET: Current_in
        public ActionResult Index()
        {
            return View(db.Current_in);
        }

        // GET: Current_in/Details/5
        public ActionResult Details(int? id)
          
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Current_in current_In = db.Current_in.Find(id);
                if (current_In == null)
                {
                    return HttpNotFound();
                }
                return View(current_In);
            }
        

        // GET: Current_in/Create
        public ActionResult Create()
        {
            var roomModel = new Current_in();
            roomModel.roomlist = from r in db.booking
                                 where r.status == "verified"
                                 select r;
            return View(roomModel);
        }

        // POST: Current_in/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,room_id")] Current_in current_In)
        {
            try
            {
                ViewBag.roomlist = new SelectList(db.booking, "room_id");
                db.Current_in.Add(current_In);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(current_In);
            }
        }

        // GET: Current_in/Edit/5
        public ActionResult Edit(int ? id)
        {
            return View();
        }

        // POST: Current_in/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Current_in/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Current_in current_In= db.Current_in.Find(id);
            if (current_In == null)
            {
                return HttpNotFound();
            }
            return View(current_In);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Current_in current_In= db.Current_in.Find(id);
            db.Current_in.Remove(current_In);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
