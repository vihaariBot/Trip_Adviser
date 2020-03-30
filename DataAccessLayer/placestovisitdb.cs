using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class placestovisitdb
    {
        public List<placedata> locationplaces(int lid)
        {
            List<placedata> places = new List<placedata>();
            TAmodel model = new TAmodel();
            var ptvs = from i in model.Placestovisits where i.locationid == lid select i;
            foreach(var i in ptvs)
            {
                placedata place = new placedata();
                place.address = i.address;
                place.locationid = i.locationid;
                place.placename = i.placename;
                place.ptvid = i.ptvid;
                var rating = (from k in model.ratings where k.itemtype == "placestovisit" && k.itemid == i.ptvid select k.Rating);
                if(rating.Any())
                {
                    place.rating = rating.Average();
                }
                else
                {
                    place.rating = 0;
                }
                places.Add(place);
            }
            return places;
        }
        public List<placedata> sortrating(int lid)
        {
            List<placedata> places = locationplaces(lid);
            places.Sort(new ratingcomparer());
            return places;
        }
        public List<placedata> mustwatch(int lid)
        {
            List<placedata> allplaces = locationplaces(lid);
            List<placedata> places= new List<placedata>();
            foreach(var i in allplaces)
            {
                if(i.rating>=3)
                {
                    places.Add(i);
                }
            }
            return places;
        }


    }
    public class ratingcomparer : IComparer<placedata>
    {
        public int Compare(placedata x, placedata y)
        {
            if(x.rating>y.rating)
            {
                return -1;
            }
            else if(x.rating<y.rating)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }



    public class placedata
    {
        public int ptvid { get; set; }
        public string placename { get; set; }
        public int locationid { get; set; }
        public string address { get; set; }
        public double rating { get; set; }
    }
}
