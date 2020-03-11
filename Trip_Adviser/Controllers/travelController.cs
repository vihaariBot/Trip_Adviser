using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using Trip_Adviser.Models;

namespace Trip_Adviser.Controllers
{
    public class travelController : Controller
    {
        // GET: travel
        public ActionResult travelhome()
        {
            database database = new database();
            List<locationdata> locations = database.travellocations();
            SelectListItem[] locs = new SelectListItem[locations.Count()];
            int j = 0;
            foreach(var i in locations)
            {
                locs[j] = new SelectListItem() { Text = i.locationname, Value =i.locationid.ToString() };
                j++;
            }
            ViewBag.locations = locs;
            SelectListItem[] modeoftravel = new SelectListItem[3];
            modeoftravel[0] = new SelectListItem() { Text = "bus", Value = "bus" };
            modeoftravel[1] = new SelectListItem() { Text = "travel", Value = "train" };
            modeoftravel[2] = new SelectListItem() { Text = "air", Value = "air" };
            ViewBag.modeoftravel = modeoftravel;
            return View();
            
        }
        public ActionResult routepage(travelinputmodel model)
        {
            database database = new database();
            List<routedata> routes= database.routes(model.fromlocation, model.tolocation, model.modeoftravel);
            return View(routes);
        }
    }
}