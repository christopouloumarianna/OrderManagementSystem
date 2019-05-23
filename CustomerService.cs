using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderManagementSystem
{
    public class CustomerService : ICustomerService
    {
        public Customer Register(string email, string name, string address, DateTime dateOfBirth)
        {

            if (dateOfBirth.AddYears(18) >= DateTime.Now)

            { return null; }

            var context = new OrderManagementDbContext();

            var customer = new Customer(email, name, address, dateOfBirth);
            context.Add(customer);
            context.SaveChanges();

            return customer;



        }

        public bool Delete(string email)
        {
            try
            {

                var context = new OrderManagementDbContext();
                var cust = context.Set<Customer>().SingleOrDefault(c => c.Email == email);
                if (cust != null)

                {

                    cust.IsActive = false;

                    context.SaveChanges();

                }

                else

                {

                    Console.WriteLine("Not found email");

                }

                return true;



            }

            catch (Exception e)

            {



                return false;

            }

        }

        public bool AddBasket(string email, Basket basket)
        {
            try
            {


                var context = new OrderManagementDbContext();
                var cus = context.Set<Customer>().SingleOrDefault(c => c.Email == email);

                var bas = context.Set<Basket>().SingleOrDefault(b => b.BasketId == basket.BasketId);

                if (cus != null && bas != null)

                {

                    context.Add(bas);

                    context.SaveChanges();

                }
                else
                {
                    Console.WriteLine("Not found basket");
                }

                return true;

            }

            catch (Exception e)

            {



                return false;

            }

        }







        public bool DeleteBasket(string email, int basketId)
        {
            try
            {
                var context = new OrderManagementDbContext();
                var cus = context.Set<Customer>().SingleOrDefault(c => c.Email == email);

                var bas = context.Set<Basket>().SingleOrDefault(b => b.BasketId == basketId);

                if (cus != null && bas != null)

                {

                    context.Remove(bas);

                    context.SaveChanges();

                }
                else
                {
                    Console.WriteLine("Not found basket");
                }

                return true;

            }

            catch (Exception e)

            {



                return false;

            }




        }

        public List<Customer> GetRecentCustomers()
        {
            var context = new OrderManagementDbContext();
            var recentCustomers = new List<Customer>();
            recentCustomers = context.Set<Customer>()
                 .Where(c => c.DateOfRegister.AddDays(7) >= DateTime.Today)
                 .ToList();

            return recentCustomers;
        }

        public bool Update(string email, string name, string address, DateTime dateOfBirth)
        {
            try
            {
                var context = new OrderManagementDbContext();
                var updating = context.Set<Customer>().SingleOrDefault(c => c.Email == email);
                if (updating != null)
                {
                    updating.Email = email;
                    updating.Name = name;
                    updating.Address = address;
                    updating.DateOfBirth = dateOfBirth;


                    context.SaveChanges();


                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

