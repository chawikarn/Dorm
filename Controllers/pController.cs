using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DormitoryWeb.Controllers
{
    public class pController : Controller
    {
        // GET: p
        public ActionResult Index()
        {
            return View();
        }

        // GET: p/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: p/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: p/Create
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

        // GET: p/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: p/Edit/5
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

        // GET: p/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: p/Delete/5
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
