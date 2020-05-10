using Microsoft.EntityFrameworkCore;
using ShoeStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore.Data
{
    public partial class ShoeStoreContext:DbContext
    {
        public ShoeStoreContext(DbContextOptions<ShoeStoreContext> options):base(options)
        {
           // Database.Migrate();
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-Q3V5PD4;Database=ShoeDB;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<User>().HasKey(u => u.Id);
        //    modelBuilder.Entity<Address>().ToTable("Address");
        //    modelBuilder.Entity<Brand>().ToTable("Brand");
        //    modelBuilder.Entity<Cart>().ToTable("Cart");
        //    modelBuilder.Entity<Order>().ToTable("Order");
        //    modelBuilder.Entity<OrderItem>().ToTable("OrderItem");
        //    modelBuilder.Entity<Product>().ToTable("Product");
        //    modelBuilder.Entity<User>().ToTable("User");
        //}

    }
    
    

}
