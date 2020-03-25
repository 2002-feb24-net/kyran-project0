using System;
using System.Collections.Generic;
using System.Text;
using Project_0.Lib.Entities;

namespace Project_0.App
{
    class AltMain
    {
        private static readonly Game_RealmContext ctx = new Game_RealmContext();
        private static void TylerMain(string[] args)
        {
            Customer c = new Customer();

            
            c.FirstName = Console.ReadLine();
            
            c.LastName = Console.ReadLine();
            
            c.Email = Console.ReadLine();

            ctx.Customer.Add(c);

            ctx.SaveChanges();
        }
    }
}
