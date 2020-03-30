using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;

namespace Trip_Adviser.Controllers
{
    public class commonController : Controller
    {
        // GET: common
        public ActionResult addcomment(string itemtype, int itemid)
        {
            //ViewBag.itemtype = itemtype;

            //ViewBag.itemid = itemid;
            //addcomentmodel obj = new addcomentmodel();
            return View();
        }
        [HttpPost]
        public ActionResult addcomment(addcommentmodel model)
        {
            common db = new common();
            db.addcomment(model.itemtype, model.itemid, model.rating);
            return RedirectToAction("mainpage", "Login");
        }
    }
}