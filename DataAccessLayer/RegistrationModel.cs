using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DataAccessLayer
{
   public class RegistrationModel
    {
        public int UID { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Compare("password")]
        public string cpassword { get; set; }
        [Required]
        public string EMAILID { get; set; }
    }
}
