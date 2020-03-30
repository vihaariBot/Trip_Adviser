using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;

namespace Trip_Adviser.Controllers
{
    public class lodgeController : Controller
    {
        // GET: lodge
        public ActionResult Lodge()
        {
            lodgedb database = new lodgedb();
            int locationid = int.Parse(Session["locationid"].ToString());
            List<lodgedata> lodges = database.alllodges(locationid);
            return View(lodges);
        }
        public ActionResult selectlodge(int lodgeid)
        {
            lodgedb database = new lodgedb();
            lodgedata lodge = database.lodge(lodgeid);
            return View(lodge);
        }
        public ActionResult lodgessortprice()

        {
            lodgedb database = new lodgedb();
            int locationid = int.Parse(Session["locationid"].ToString());
            List<lodgedata> lodges = database.sortprice(locationid);
            return View(lodges);
        }
        public ActionResult lodgessortrating()
        {
            lodgedb database = new lodgedb();
            int locationid = int.Parse(Session["locationid"].ToString());
            List<lodgedata> lodges = database.sortrating(locationid);
            //return RedirectToAction("lodgessortprice", "Lodge", lodges);
            return View(lodges);
        }
    }
}