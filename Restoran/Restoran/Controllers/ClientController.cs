using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restoran.Models;

namespace Restoran.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            this._context = context;
        }

        // GET: api/Client
        [HttpGet]
        public string GetClient()
        {
            var clients = _context.Clients.ToList();
            return JsonConvert.SerializeObject(clients, Formatting.Indented);
        }


        // POST: api/Client
        [HttpPost]
        public string PostClient([FromForm] Client clients)
        {
            
            _context.Clients.Add(clients);
            _context.SaveChanges();

            return GetClient();
        }
    }
}