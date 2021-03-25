using DormitoryWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DormitoryWeb.Controllers
{
    public class Elec_waterController : Controller
    {

        private Entities8 db = new Entities8();
        // GET: Elec_water
        public ActionResult Index()
        {
            return View(db.Electronic);
        }

        public ActionResult Index1()
        {
            return View(db.Water);
        }

        // GET: Elec_water/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Elec_water/Create
        public ActionResult Create()
        {
            var roomModel = new Electronic();
            roomModel.roomlist = from r in db.booking
                                 where r.status == "verified"
                                 select r;

            return View(roomModel);


        }

        // POST: Elec_water/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,room_id,meter,date,month")] Electronic electronic)
        {
            try
            {
                db.Electronic.Add(electronic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(electronic);
            }
        }



        public ActionResult Create2()
        {
            var roomModel = new Water();
            roomModel.roomlist = from r in db.booking
                                 where r.status == "verified"
                                 select r;

            return View(roomModel);


        }

        // POST: Elec_water/Create
        [HttpPost]
        public ActionResult Create2([Bind(Include = "Id,room_id,meter,date,month")] Water water)
        {
            try
            {
                db.Water.Add(water);
                db.SaveChanges();
                return RedirectToAction("Index1");
            }
            catch
            {
                return View(water);
            }
        }















        // GET: Elec_water/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Elec_water/Edit/5
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

        // GET: Elec_water/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Elec_water/Delete/5
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
