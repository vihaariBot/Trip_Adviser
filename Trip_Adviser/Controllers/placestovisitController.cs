using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
namespace Trip_Adviser.Controllers
{
    public class placestovisitController : Controller
    {
        // GET: placestovisit
        public ActionResult viewallplaces()
        {
            placestovisitdb database = new placestovisitdb();
            List<placedata> places = database.locationplaces(1);

            return View(places);
        }
        public ActionResult place(int pid)
        {
            placestovisitdb database = new placestovisitdb();
            List<placedata> places = database.locationplaces(1);
            placedata place = places.Where(i => i.ptvid == pid).Select(i => i).FirstOrDefault();
            return View(place);
        }
        public ActionResult sortrating()
        {
            placestovisitdb database = new placestovisitdb();
            List<placedata> places = database.sortrating(1);

            return View(places);
        }
    }
}