using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class logindb
    {
        public int Login(string username, string password)
        {
            TAmodel m = new TAmodel();

            var uid = (from a in m.Registrations
                       where a.USER_NAME == username && a.PASSWORD == password
                       select a.USER_ID).FirstOrDefault();
            int id = int.Parse(uid.ToString());
            return id;
        }

        public void Register(string un, string pass, string eid)
        {
            TAmodel m = new TAmodel();
            Registration r = new Registration();
            r.USER_NAME = un;
            r.PASSWORD = pass;
           
            r.EMAILID = eid;
            m.Registrations.Add(r);
            m.SaveChanges();

        }
        public List<Locationmenu> LocationSearch()
        {
            TAmodel t = new TAmodel();
            List<Locationmenu> LocationList = new List<Locationmenu>();
            var res = from a in t.locations
                      select a;
            foreach (var rec in res)
            {
                Locationmenu loc = new Locationmenu();
                loc.LID = rec.locationid;
                loc.LNAME = rec.locationname;
                loc.DESC = rec.description;
                LocationList.Add(loc);
            }
            return LocationList;
        }
    }
}
