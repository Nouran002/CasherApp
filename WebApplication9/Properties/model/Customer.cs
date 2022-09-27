using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Properties.model
{
    public class CustomerLogin
    {
        public string email { get; set; }
        public string password { get; set; }
    }
    public class CustomerRegister
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
    }
    public class Customer
    {
      public int id { get; set; }
        public string CustomerCode { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public float change { get; set; }
        public string notes { get; set; }
        public ICollection<Order> orders { get; set; }
    }
}
