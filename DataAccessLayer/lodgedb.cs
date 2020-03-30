using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class lodgedb
    {
        public List<lodgedata> alllodges(int locationid)
        {
            TAmodel data = new TAmodel();
            var dblodges = from i in data.Lodges where i.LOCATION_ID == locationid select i;
            List<lodgedata> lodges = new List<lodgedata>();
            foreach (var i in dblodges)
            {
                lodgedata l = new lodgedata();
                l.LODGE_ID = i.LODGE_ID;
                l.LODGE_NAME = i.LODGE_NAME;
                l.LODGE_ADD = i.LODGE_ADD;
                l.LOCATION_ID = i.LOCATION_ID;
                l.PRICE = i.PRICE;
                var ratings = (from k in data.ratings where k.itemtype == "lodge" && k.itemid == i.LODGE_ID select k.Rating);
                if(ratings.Any())
                {
                    l.rating = ratings.Average();
                }
                else
                {
                    l.rating = 0;
                }
                lodges.Add(l);
            }
            return lodges;

        }
        public lodgedata lodge(int lodgeid)
        {
            TAmodel data = new TAmodel();
            var lodge = (from i in data.Lodges where i.LODGE_ID == lodgeid select i).FirstOrDefault();
            lodgedata l = new lodgedata();
            var ratings = (from k in data.ratings where k.itemtype == "lodge" && k.itemid == lodgeid select k.Rating);
            if (ratings.Any())
            {
                l.rating = ratings.Average();
            }
            else
            {
                l.rating = 0;
            }
           
            l.LODGE_ID = lodge.LODGE_ID;
            l.LODGE_NAME = lodge.LODGE_NAME;
            l.LODGE_ADD = lodge.LODGE_ADD;
            l.LOCATION_ID = lodge.LOCATION_ID;
            l.PRICE = lodge.PRICE;
            //l.rating = rating;
            return l;

        }
      
        public List<lodgedata> sortprice(int locationid)
        {

            List<lodgedata> lodges = alllodges(locationid);
            lodges.Sort(new pricecomparer());
            return lodges;
        }


        public List<lodgedata> sortrating(int locationid)
        {
            List<lodgedata> lodges = alllodges(locationid);
            lodges.Sort(new lodgeratingcomparer());
            return lodges;
        }
    }
    public class pricecomparer : IComparer<lodgedata>
    {
        public int Compare(lodgedata x, lodgedata y)
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
    public class lodgeratingcomparer : IComparer<lodgedata>
    {
        public int Compare(lodgedata x, lodgedata y)
        {
            if (x.rating < y.rating)
            {
                return -1;
            }
            else if (x.rating > y.rating)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
    public class lodgedata
    {
        public int LODGE_ID;


        public int LOCATION_ID;

        public string LODGE_NAME;

        public string LODGE_ADD;

        public int PRICE;
        public double rating;

    }
}

