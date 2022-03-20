using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.Models
{
    internal class Account
    {
        public string userName { get; set; }
        public string fullName { get; set; }
        public string dateOfBirth { get; set; }
        public int gender { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string password { get; set; }
        public int type { get; set; }
    }
}
