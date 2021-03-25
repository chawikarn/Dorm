using DormitoryWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DormitoryWeb.Controllers
{
    public class RoomManagementController : Controller
    {
        // GET: RoomManagement
        private Entities8 db = new Entities8();
        public ActionResult Index()
        {
            return View(db.Room);
        }

        // GET: RoomManagement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoomManagement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomManagement/Create
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

        // GET: RoomManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room Rooms = db.Room.Find(id);
            if (Rooms == null)
            {
                return HttpNotFound();
            }

            return View(Rooms);
        }

        // POST: RoomManagement/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "room_id, type_id, status, url, Room_info")] Room Rooms)
        {
            try
            {
                db.Entry(Rooms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(db.Room);
            }
        }

        // GET: RoomManagement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoomManagement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
