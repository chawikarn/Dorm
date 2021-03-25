using DormitoryWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DormitoryWeb.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        private Entities8 db = new Entities8();

        public ActionResult Index()
        {
            ViewBag.listRoom = db.Room.ToList();
            return View();
        }
    }
}