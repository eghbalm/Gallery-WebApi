using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using PicoSystem_Gallery.Models;

namespace PicoSystem_Gallery.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        mdl_Gallery db = new mdl_Gallery();
        public ActionResult Index()
        {
            //IEnumerable<tbl_Users> Users = GetEnumerable;
            //db.Database.Delete();
            //db.Database.Initialize(true);
            return View();
        }
        public ActionResult UploadPhoto(int Id)
        {
            tbl_Users tbu = db.tbl_Users.Find(Id);
            if (tbu==null)
            {
                return RedirectToAction("index");
            }
            return View(Id);
        }
        public ActionResult ListUser()
        {
            return View();
        }
        public ActionResult AllPhotos()
        {
            return View();
        }
    }
}