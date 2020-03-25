using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using Project_0.Lib.Entities;

namespace Store
{
    class MainMethod
    {

        //allows us to update the DATABASE
        private static readonly Game_RealmContext ctx = new Game_RealmContext();
        static void Main(string[] args)
        {
          


            Console.WriteLine("Welcome to Game Realm!\n");
            Thread.Sleep(1200);
            promptUser.promtUserMenu(ctx);


        }
    }
}
