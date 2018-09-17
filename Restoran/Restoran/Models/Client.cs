using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.Models
{
    public class Client : Entity //Клиент
    {
        
        [FromForm(Name = "contact")] public string Contact { get; set; }
        [FromForm(Name = "name")] public string Name { get; set; }
        
        [FromForm(Name = "orderId")]
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}