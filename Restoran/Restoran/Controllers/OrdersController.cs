using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restoran;
using Restoran.Models;

namespace Restoran.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            this._context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public string GetOrders()
        {
            var orders = _context.Orders.ToList();
            return JsonConvert.SerializeObject(orders, Formatting.Indented);
        }


        // POST: api/Orders
        [HttpPost]
        public string PostOrders([FromForm] Order oreder)
        {    
            oreder.Date = DateTime.Now;
            _context.Orders.Add(oreder);
            _context.SaveChanges();

            return GetOrders();
        }
    }
}