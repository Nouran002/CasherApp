using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication9.Properties.model;


namespace WebApplication9.Properties.Controller
{
    [ApiController]
    [Route("[Controller]")]
    public class AdminController:ControllerBase
    {
        LibraryContext _context;
        IMapper _mapper;
        public AdminController(LibraryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost("AdminRegister")]
        public ActionResult add(AdminRegister a)
        {
            Admin d = _mapper.Map<Admin>(a);
            _context.admins.Add(d);
            _context.SaveChanges();
            return Ok("Done");
        }
        [HttpPost("AdminLogin")]
        public ActionResult Login(AdminLogin log)
        {
            var admin = _context.admins.Where(x => x.email == log.email && x.password == log.password).FirstOrDefault();
            if (admin == null)
            {
                return Unauthorized("Invalid username or password");
            }
            return Ok(admin);
        }
        [HttpPost("DeleteCustomer")]
        public ActionResult DeleteCustomer ([FromForm]int id)
        {
            var customer = _context.customers.Where(s => s.id == id).FirstOrDefault();
            if (customer == null)
            {
                return BadRequest("there is no customer with this id");
            }
            _context.customers.Remove(customer);
            _context.SaveChanges();
            return Ok("Done");
        }
        [HttpPost("UpdateCustomer")]
        public ActionResult UpdateCustomer([FromQuery]int id,[FromBody]CustomerRegister reg)
        {
            var u = _context.customers.AsNoTracking().Where(c => c.id == id).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("there is no customer with this id");
            }
            Customer c = new Customer
            {
                id = id,
                name = reg.name ?? u.name,
                email = reg.email ?? u.email,
                password = reg.password ?? u.password,
                phone = reg.phone ?? u.phone,
                address = reg.address ?? u.address
            };
            _context.customers.Update(c);
            _context.SaveChanges();
            return Ok("Done");
                
        }
        [HttpGet("GetAllCustomers")]
        public ActionResult getAllCustomers()
        {
            var List = _context.customers.Include(c => c.orders).ThenInclude(v => v.items).ThenInclude(a => a.product)
                .ThenInclude(s => s.categories).ToList();
            return Ok(List);
        }
       
        [HttpPost("DeleteProduct")]
        public ActionResult DeleteProduct([FromForm]int id)
        {
            var product = _context.products.Where(s => s.id == id).FirstOrDefault();
            if (product == null)
            {
                return BadRequest("there is no customer with this id");
            }
            _context.products.Remove(product);
            _context.SaveChanges();
            return Ok("Done");
        }
        [HttpPost("AddProduct")]
        public ActionResult AddProduct(Product p)
        {
            bool o = _context.products.Any(m => m.id == p.id);
            if (o == true)
            {
                return BadRequest("there is a custmer with same id");
            }
            else
            {
                _context.products.Add(p);
                _context.SaveChanges();
                return Ok("Done");
            }

        }

        [HttpPost("UpdateProduct")]
        public ActionResult UpdateProduct([FromQuery]int id,[FromBody] ProductDetails det)
        {
            var l = _context.products.AsNoTracking().Where(c => c.id == id).FirstOrDefault();
            if (l == null)
            {
                return BadRequest("there is no product with this id");
            }
            Product s = new Product
            {
                id = id,
                productName = det.productName ?? l.productName,
                productCode = det.productCode ?? l.productCode,
                originalPrice = det.originalPrice ?? l.originalPrice,
                productQuantity=det.productQuantity?? l.productQuantity,
                ImagePath=det.ImagePath?? l.ImagePath,
                sellingPrice=det.sellingPrice?? l.sellingPrice,
                notes=det.notes?? l.notes
            };
            _context.products.Update(s);
            _context.SaveChanges();
            return Ok("Done");

        }
        [HttpPost("AddImage")]
        public ActionResult AddImage(IFormFile file)
        {
            string fullPath = Directory.GetCurrentDirectory() + "/images";

            string name = DateTime.Now.Ticks.ToString() + file.FileName;

            string filepath = fullPath + "/" + name;

            var stream = new FileStream(filepath, FileMode.Create);

            file.CopyTo(stream);

            return Ok(name);
        }
        public ActionResult AddCategory(Category c)
        {
            bool o = _context.categories.Any(m => m.id == c.id);
            if (o == true)
            {
                return BadRequest("there is a category with same id");
            }
            else
            {
                _context.categories.Add(c);
                _context.SaveChanges();
                return Ok("Done");
            }

        }
        [HttpPost("DeleteCategory")]
        public ActionResult DeleteCategory([FromForm]int id)
        {
            var category= _context.products.Where(s => s.id == id).FirstOrDefault();
            if (category == null)
            {
                return BadRequest("there is no Category with this id");
            }
            _context.products.Remove(category);
            _context.SaveChanges();
            return Ok("Done");
        }
        [HttpPost("UpdateCategory")]
        public ActionResult UpdateCategory([FromQuery]int id,[FromBody]catDetails cat)
        {
            var u = _context.categories.AsNoTracking().Where(c => c.id == id).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("there is no category with this id");
            }
            Category c = new Category
            {
                id = id,
               CategoryName=cat.CategoryName?? u.CategoryName
                
            };
            _context.categories.Update(c);
            _context.SaveChanges();
            return Ok("Done");

        }


    }
}
