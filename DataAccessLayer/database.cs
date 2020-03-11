using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class database
    {
        
        public List<locationdata> travellocations()
        {
            TAmodel data = new TAmodel();
            var databaselocations = from i in data.locations select i;
            List<locationdata> locations = new List<locationdata>();
            foreach(var i in databaselocations)
            {
                locationdata ldata = new locationdata();
                ldata.locationid = i.locationid;
                ldata.locationname = i.locationname;
                ldata.description = i.description;
                locations.Add(ldata);
            }
            return locations;
        }
       
    }
    public class locationdata
    {
        public int locationid;
        public string locationname;
        public string description;
    }
}
