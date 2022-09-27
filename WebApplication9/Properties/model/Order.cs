using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Properties.model
{
    public class OrderDetails
    {
        public int CustomerId { get; set; }
        public DateTime date { get; set; }
        public List<OrderItem> list { get; set; }

    }
    public class Order
    {
        
        public int id { get; set; }
        public DateTime date { get; set; }
        public string OrderName { get; set; }//عاوزه اعمل كونكات فيها بين  الكاستمر id و الوقت
        public float totalPayment { get; set; }

        public int CustomerId { get; set; }
        public Customer customer { get; set; }
        

        public ICollection<OrderItem> items { get; set; }
    }
}
