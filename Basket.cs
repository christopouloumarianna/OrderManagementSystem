using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderManagementSystem
{
    
    
        public class Basket

        {
        [Key]
            public int BasketId { get; set; }

           
        public Customer Customer { get; set; }


        public int CustomerId { get; set; }

        public List<BasketProduct> basketproducts { get; set; }

       
    }
    }

