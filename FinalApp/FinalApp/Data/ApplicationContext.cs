using FinalApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalApp.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                .HasKey(nameof(Product.ProductId));
            //modelBuilder.Entity<Product>()
            //    .Property(nameof(Product.Status))
            //    .HasConversion(new EnumToNumberConverter<IssueStatus, int>())
            //    .HasDefaultValue(IssueStatus.Backlog);

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        
    }
}


