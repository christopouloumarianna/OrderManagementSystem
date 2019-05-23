using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderManagementSystem
{
     public class Customer 
    {
        private bool v;

        public Customer(string email, string name, string address, DateTime dateOfBirth)
        {
            Email = email;
            Name = name;
            Address = address;
            DateOfBirth = dateOfBirth;
        }

        public Customer(string email, string name, string address, DateTime dateOfBirth, bool v) : this(email, name, address, dateOfBirth)
        {
            this.v = v;
        }

        public Customer(int customerId, string name, string address, string email, List<Basket> baskets, DateTime dateOfBirth, DateTime dateOfRegister)
        {
            CustomerId = customerId;
            Name = name;
            Address = address;
            Email = email;
            this.baskets = baskets;
            DateOfBirth = dateOfBirth;
            DateOfRegister = dateOfRegister;
        }

        
       
        [Required(AllowEmptyStrings = false)]
        [IsUnique]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get;  set; }
        public DateTime DateOfRegister { get; set; }
       
        public List<Basket> baskets { get; set; }
        [Key]
        public int CustomerId { get; set; }

        public override string ToString()
        {
            return $"{CustomerId}, {Name}, {Address}, {Email}, {baskets}, {DateOfBirth}, {DateOfRegister} {IsActive} ";
        }
    }
}
