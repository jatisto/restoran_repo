using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Restoran.Models
{
    public class Dish : Entity // Блюдо
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}