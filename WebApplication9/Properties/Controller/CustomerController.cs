using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication9.Properties.model;

namespace WebApplication9.Properties.Controller
{
    [ApiController]
    [Route("Customer")]
    //[Route("/api[Controller]")]



    public class CustomerController:ControllerBase
    {
        LibraryContext _context;
        IMapper _mapper;
        public CustomerController(LibraryContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       
        [HttpPost("CustomerRegister")]
        public ActionResult add(CustomerRegister s)
        {
            Customer c = _mapper.Map<Customer>(s);
            _context.customers.Add(c);
            _context.SaveChanges();
            return Ok("Done");
        }
        [HttpPost("CustomerLogin")]
        public ActionResult Login(CustomerLogin log)
        {
            var customer = _context.customers.Where(l => l.email == log.email && l.password == log.password).FirstOrDefault();
            if (customer == null)
            {
                return Unauthorized("Invalid username or password");
            }
            return Ok(customer);
        }

        [HttpGet("GetAllProducts")]
        public ActionResult GetAllProducts()
        {
            return Ok(_context.products.ToList());
        }
       

    }
}
