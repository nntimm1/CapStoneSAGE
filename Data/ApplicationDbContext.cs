using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SAGEWebsite.Models;

namespace SAGEWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public DbSet<SAGEWebsite.Models.Customer> Customers { get; set; }
        public DbSet<SAGEWebsite.Models.Location> Locations { get; set; }
        public DbSet<SAGEWebsite.Models.Address> Addresses { get; set; }
        public DbSet<SAGEWebsite.Models.Item> Items { get; set; }
        public DbSet<SAGEWebsite.Models.Order> Orders { get; set; }
        public DbSet<SAGEWebsite.Models.Payment> Payments { get; set; }
        public DbSet<SAGEWebsite.Models.Survey> Surveys { get; set; }
        public DbSet<SAGEWebsite.Models.Contact> Contact { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
               .HasData(
                   new IdentityRole
                   {
                       Name = "Customer",
                       NormalizedName = "CUSTOMER"
                   }
              );
        }
    }
 }


