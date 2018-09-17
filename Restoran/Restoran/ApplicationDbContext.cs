using System.IO;
using Restoran.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace Restoran
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Institution>()
                .HasData(JsonConvert.DeserializeObject<Institution[]>(File.ReadAllText("JsonFile/Institution.json")));
            modelBuilder.Entity<Client>()
                .HasData(JsonConvert.DeserializeObject<Client[]>(File.ReadAllText("JsonFile/Client.json")));
            modelBuilder.Entity<Dish>()
                .HasData(JsonConvert.DeserializeObject<Dish[]>(File.ReadAllText("JsonFile/Dish.json")));
            modelBuilder.Entity<Order>()
                .HasData(JsonConvert.DeserializeObject<Order[]>(File.ReadAllText("JsonFile/Order.json")));
        }
    }
}