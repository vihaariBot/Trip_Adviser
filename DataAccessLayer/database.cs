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
        public List<routedata> routes(int fromlocation,int tolocation,string modeoftravel)
        {
            TAmodel data = new TAmodel();
            var hops = from i in data.hops where i.hoplocation==fromlocation || i.hoplocation==tolocation select i;
            //var dbroutes = from i in data.routes.Include("location") select i;
            var dbroutes = data.routes.Include("fromloc").Include("toloc").Where(i=>i.modeoftravel==modeoftravel).Select(i => i); 
            List<routedata> routes = new List<routedata>();
            
            bool flag = true;
            foreach (var i in hops)
            {
                
                foreach(var j in hops)
                {
                    if(i.hopid!=j.hopid)
                    {
                        if(i.routeid== j.routeid)
                        {
                            routedata route = new routedata();
                           
                            var sroute = (from p in dbroutes where p.routeid == i.routeid select p).FirstOrDefault();
                            if (sroute != null)
                            {
                                route.routeid = sroute.routeid;
                                route.fromlocation = sroute.fromloc.locationname;
                                route.tolocation = sroute.toloc.locationname;
                                foreach (var z in routes)
                                {
                                    if (z.routeid == route.routeid)
                                    {
                                        flag = false;
                                    }
                                }
                                if (flag)
                                {
                                    routes.Add(route);
                                    flag = true;
                                }
                                flag = true;
                            }
                        }
                    }
                }
            }
            return routes;
        }
    }
   
    

   
}
