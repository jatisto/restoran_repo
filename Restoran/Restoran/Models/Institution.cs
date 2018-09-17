using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Restoran.Models
{
    public class Institution : Entity //Заведение
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}