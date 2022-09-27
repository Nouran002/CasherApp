using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication9.Properties.model;

namespace WebApplication9.Properties.Controller
{
    [ApiController]
    [Route("Order")]
    //[Route("/api[Controller]")]


    public class OrderController:ControllerBase
    {
        List<Order> orders = new List<Order>();
        List<OrderItem> orderItems = new List<OrderItem>();
        [HttpPost("createorder")]
        public ActionResult addOrder (OrderDetails o)
        {
            Order or = new Order();
            or.CustomerId = o.CustomerId;
            or.date = DateTime.Now;
            orders.Add(or);
            foreach(var item in o.list)
            {
                OrderItem u = new OrderItem();
                u.productId = item.productId;
                u.quantity = item.quantity;
                u.sellingPrice = item.sellingPrice;
                u.Discount = item.Discount;
                u.DiscountPrice = item.DiscountPrice;
                u.totalPrice = item.totalPrice;
                u.OrderId = or.id;
                orderItems.Add(u);
            }
            return Ok("Done");
        }

       
    }
}
