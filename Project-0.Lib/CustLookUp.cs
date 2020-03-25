using System;
using System.Threading;
using System.Linq;
using Project_0.Lib.Entities;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class CustLookUp
    {
        public static void customerSearch(Game_RealmContext ctx)
        {
            Console.WriteLine("Who would you like you like to search for? \n");
            Thread.Sleep(800);
            string userINput = Console.ReadLine();

            var custSearch = from sales in ctx.Customer
                             where sales.FirstName == userINput
                             select sales;

            var custName = ctx.Customer.FirstOrDefault(cid => cid.FirstName == userINput);

            if (custName != null)
            {
                



                foreach (var item in custSearch)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("\t\t\t\t\tCustomer Found!");
                    Console.WriteLine("\n");
                    Console.WriteLine($"First Name: {item.FirstName}\nLast Name: {item.LastName}\n\nUser Name:  {item.UserName}");

                }


            }

            else
            {
                Console.WriteLine("\ninvalid Entry! or Customer not Found!\n\n");
                Thread.Sleep(1000);
                promptUser.promtUserMenu(ctx);
            }
        }

    }
}
