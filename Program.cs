using System;

namespace OrderManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new OrderManagementDbContext();
            var costumerservice = new CustomerService();
            var costumer1 = costumerservice.Register("costumer1@hotmail.com",
                "maria", "ioannou 7", new DateTime(1990, 9, 23));
            context.SaveChanges();
            Console.WriteLine(costumer1);

            //var costumer2 = costumerservice.Update("costumer2@hotmail.com",
            //    "giannis", "ioannou 31", new DateTime(1998, 10, 23));
            //context.SaveChanges();
            //Console.WriteLine(costumer2);

        }


    }
}
