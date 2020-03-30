using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class loginmodel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
