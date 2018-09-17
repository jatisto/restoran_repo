using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.Models
{
    public class Order : Entity
    {
//        [FromForm(Name = "nameRestoran")] public string NameRestoran { get; set; }
//        [FromForm(Name = "dishOrders")] public string DishOrder { get; set; }

       
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "data")]
        public DateTime? Date { get; set; }

        [FromForm(Name = "institutionId")]
        [ForeignKey("Institution")]
        public int InstitutionId { get; set; }

        public Institution Institution { get; set; }

        [FromForm(Name = "dishId")]
        [ForeignKey("Dish")]
        public int DishId { get; set; }

        public Dish Dish { get; set; }
    }
}