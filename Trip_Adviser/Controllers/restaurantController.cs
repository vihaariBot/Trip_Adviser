using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;

namespace Trip_Adviser.Controllers
{
    public class restaurantController : Controller
    {
        // GET: restaurant
        public ActionResult Restaurant()
        {
            restaurantdb database = new restaurantdb();
            int locationid = int.Parse(Session["locationid"].ToString());
            List<Restaurantdata> restaurants = database.allrestaurants(locationid);
            return View(restaurants);
        }

        public ActionResult SelectRestaurant(int restaurantid)
        {
            restaurantdb database = new restaurantdb();
            Restaurantdata restaurant = database.restaurant(restaurantid);
            return View(restaurant);
        }

        public ActionResult Sortbyprice()
        {
            restaurantdb database = new restaurantdb();
            int locationid = int.Parse(Session["locationid"].ToString());
            List<Restaurantdata> restaurants = database.sortprice(locationid);
            return View(restaurants);
        }

        public ActionResult Sortbyrating()
        {
            restaurantdb database = new restaurantdb();
            int locationid = int.Parse(Session["locationid"].ToString());
            List<Restaurantdata> restaurants = database.sortrating(locationid);
            return View(restaurants);
        }
    }
}