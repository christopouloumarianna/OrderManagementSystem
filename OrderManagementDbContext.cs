using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem
{
    
    
        public class OrderManagementDbContext : DbContext

        {
     public   DbSet<Product> Products { get; set; }
       public DbSet<Customer> Customers { get; set; }
      public  DbSet<Basket> Baskets { get; set; }


        public DbSet<BasketProduct> BasketProduct { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

            {
            string s = "Server =localhost; Database =OrderManagement; Integrated Security=SSPI;" +
              "Persist Security Info=False;";
            base.OnConfiguring(optionsBuilder.UseSqlServer(s));


            }



            protected override void OnModelCreating(ModelBuilder modelBuilder)

            {

            modelBuilder.Entity<Basket>()
             .HasOne(b => b.Customer)
             .WithMany(c => c.baskets)
             .HasForeignKey(b => b.CustomerId);


            modelBuilder.Entity<BasketProduct>()
                .HasKey(t => new { t.BasketId, t.ProductId });

            modelBuilder.Entity<BasketProduct>()
                .HasOne(pt => pt.basket)
                .WithMany(p => p.basketproducts)
                .HasForeignKey(pt => pt.BasketId);

            modelBuilder.Entity<BasketProduct>()
                .HasOne(pt => pt.product)
                .WithMany(t => t.basketproducts)
                .HasForeignKey(pt => pt.ProductId);

        }

       


    }

}
    

