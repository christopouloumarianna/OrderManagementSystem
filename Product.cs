using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderManagementSystem
{
   
    
        public class Product

        {
        [Key]
            public int ProductId { get; set; }

            public string Name { get; set; }

            public decimal Price { get; set; }

            public ProductCategory Category { get; set; }
        public  List<BasketProduct> basketproducts { get; set; }

        

        public override string ToString()
        {
            return $"{ProductId}, {Name}, {Price}, {Category}, {basketproducts}";
        }
    }
    }

