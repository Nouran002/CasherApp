using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Properties.model
{
    public class AdminLogin
    {
        public string email { get; set; }
        public string password { get; set; }
    }
    public class AdminRegister
    {
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
    }
    public class Admin
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string phone { get; set; }

    }
}
