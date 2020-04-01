using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;

namespace Trip_Adviser.Controllers
{
    public class loginController : Controller
    {
        public ActionResult LoginProcess()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginProcess(loginmodel model)
        {
            if (ModelState.IsValid)
            {
                logindb dal = new logindb();
                int result = dal.Login(model.username, model.password);
                if (result == 1)
                {
                    return RedirectToAction("Welcome", "Login");
                }
                else
                {
                    ViewBag.message="Invalid credentials";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult RegisterProcess()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterProcess(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                logindb dal = new logindb();
                dal.Register(model.username, model.password, model.EMAILID);
                return RedirectToAction("LoginProcess", "Login");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Welcome()
        {
            logindb d = new logindb();

            List<DataAccessLayer.Locationmenu> loc = d.LocationSearch();
            SelectListItem[] locs = new SelectListItem[loc.Count()];
            int j = 0;
            foreach (var i in loc)
            {
                locs[j] = new SelectListItem() { Text = i.LNAME, Value = i.LID.ToString() };
                j++;
            }
            ViewBag.locs = locs;
            return View();

        }
        [HttpPost]
        public ActionResult Welcome(int locationid)
        {
            Session["locationid"] = locationid;
            return RedirectToAction("mainpage", "login");
        }
        public ActionResult mainpage()
        {
            ViewBag.locationid = Session["locationid"];
            return View();
        }

    }
}