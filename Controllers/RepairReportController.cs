using DormitoryWeb.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DormitoryWeb.Controllers
{
    public class RepairReportController : Controller
    {
        // GET: Repair
        private Entities8 db = new Entities8();
        public ActionResult Index()
        {
            if (User.Identity.Name == "admin@mail.com")
            {
                return View(db.RepairReport);
            }
            else
            {
                var result = from b in db.RepairReport
                             join a in db.AspNetUsers
                             on b.cus_id equals a.Id
                             where a.UserName == User.Identity.Name
                             select b;

                return View(result);
            }
        }

        // GET: Repair/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Repair/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Repair/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,cus_id,header,body,File,date_time")] RepairReport repairreport)
        {
            var file = Request.Files[0];
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/RepairReport"), fileName);
                file.SaveAs(path);
                repairreport.File = fileName;
            }
            repairreport.date_time = DateTime.Now;
            repairreport.cus_id = User.Identity.GetUserId();
            db.RepairReport.Add(repairreport);
            db.SaveChanges();
            return View("ReportSuccess");
       
        }

        // GET: Repair/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Repair/Edit/5
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

        // GET: Repair/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Repair/Delete/5
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
        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Content/RepairReport"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}
