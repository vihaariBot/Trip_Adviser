using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class common
    {
        public void addcomment(string itemtype, int itemid, int rating)
        {
            TAmodel data = new TAmodel();
            rating r = new rating();
            // r.Rating_ID = 2;
            r.itemid = itemid;
            r.itemtype = itemtype;
            r.Rating = rating;
            r.ratedby = 1;
            data.ratings.Add(r);
            data.SaveChanges();

        }
    }
}
