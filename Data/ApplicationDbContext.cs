using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SAGEWebsite.Models;

namespace SAGEWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<Payment> Payments{ get; set; }
        public DbSet<Survey> Surveys { get; set; }





    }
}
