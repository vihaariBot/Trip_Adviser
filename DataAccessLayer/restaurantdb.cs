using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class restaurantdb
    {
        public List<Restaurantdata> allrestaurants(int locationid)
        {
            TAmodel data = new TAmodel();
            var dbrestaurant = from i in data.Restaurants where i.LOCATION_ID == locationid select i;

            List<Restaurantdata> restaurants = new List<Restaurantdata>();
            foreach (var i in dbrestaurant)
            {
                Restaurantdata r = new Restaurantdata();
                r.RESTAURANT_ID = i.RESTAURANT_ID;
                r.RESTAURANT_NAME = i.RESTAURANT_NAME;
                r.ADRESS = i.ADRESS;
                r.LOCATION_ID = i.LOCATION_ID;
                r.PRICE = i.PRICE;
                var ratings= (from k in data.ratings where k.itemtype == "restaurant" && k.itemid == i.RESTAURANT_ID select k.Rating);
                if(ratings.Any())
                {
                    r.rating = ratings.Average();
                }
                restaurants.Add(r);
            }
            return restaurants;
        }

        public Restaurantdata restaurant(int restaurantid)
        {
            TAmodel data = new TAmodel();
            var restaurant = (from i in data.Restaurants where i.RESTAURANT_ID == restaurantid select i).FirstOrDefault();
            var ratings = (from i in data.ratings where i.itemtype == "Restaurant" && i.itemid == restaurantid select i.Rating);

            Restaurantdata r = new Restaurantdata();
            r.RESTAURANT_ID = restaurant.RESTAURANT_ID;
            r.RESTAURANT_NAME = restaurant.RESTAURANT_NAME;
            r.ADRESS = restaurant.ADRESS;
            r.LOCATION_ID = restaurant.LOCATION_ID;
            r.PRICE = restaurant.PRICE;
            if (ratings.Any())
            {
                r.rating = ratings.Average();
            }
           
            return r;

        }

       

        public List<Restaurantdata> sortprice(int locationid)
        {
            List<Restaurantdata> restaurants = allrestaurants(locationid);
            restaurants.Sort(new pricecomparer());
            return restaurants;
        }

        public class pricecomparer : IComparer<Restaurantdata>
        {
            public int Compare(Restaurantdata x, Restaurantdata y)
            {
                if (x.PRICE < y.PRICE)
                {
                    return -1;
                }
                else if (x.PRICE > y.PRICE)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public List<Restaurantdata> sortrating(int locationid)
        {
            List<Restaurantdata> restaurants = allrestaurants(locationid);
            restaurants.Sort(new ratingcomparer());
            return restaurants;
        }

        public class ratingcomparer : IComparer<Restaurantdata>
        {
            public int Compare(Restaurantdata x, Restaurantdata y)
            {
                if (x.rating > y.rating)
                {
                    return -1;
                }
                else if (x.rating < y.rating)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }


    }

    public class Restaurantdata
    {
        public int RESTAURANT_ID;
        public string RESTAURANT_NAME;
        public int LOCATION_ID;
        public string ADRESS;
        public int PRICE;
        public double rating;
    }
}
