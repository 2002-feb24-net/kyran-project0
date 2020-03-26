using System;
using System.Linq;
using System.Threading;
using Project_0.Lib.Entities;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public static class CustStorage
    {
        private static readonly int userInput = int.Parse(Console.ReadLine());

        public static Customer custLogin(Game_RealmContext ctx, Customer cust)
        {
            


            Console.WriteLine("Please Enter your credentials\n\n");
            Console.Write("Username: ");
            var userName = Console.ReadLine();
            Console.Write("Password: ");
            var custPass = Console.ReadLine();
            Thread.Sleep(400);



            var customer = from sales in ctx.Customer            
                             where sales.UserName == userName && sales.Password == custPass
                             select sales;

             cust = ctx.Customer.Where(c => c.UserName == userName && c.Password == custPass).SingleOrDefault();
            
            /* Customer custID = ctx.Customer.Where(cid => cid.CustomerId == customerID).SingleOrDefault();*/
            if (cust.UserName.ToUpper() != null)
            {
                if (cust.Password == custPass)
                {
                    Console.WriteLine("\nWelcome back: " + cust.FirstName + " " + cust.LastName + "!\n");
                }
            }

            else if (cust == null)
            {
                Console.WriteLine("Username or Password is incorrect\n");
                Thread.Sleep(900);
                Console.WriteLine("Would you like to try again? (y/n)");
                var answer = Console.ReadLine();

                if (answer.ToUpper() == "Y")
                {
                    custLogin(ctx, cust);
                }
                else
                {
                    promptUser.promtUserMenu(ctx, cust);
                }
            }

            return cust;
        }
    }
}
