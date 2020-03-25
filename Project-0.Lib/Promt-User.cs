using System;
using Project_0.Lib.Entities;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

namespace Store
{
    public static class promptUser
    {

        public static void promtUserMenu(Game_RealmContext ctx)
        {

            Console.WriteLine("What would you like to do? \n");
            Thread.Sleep(800);

            Console.WriteLine("\t1) New Customer\n" + "\t2) Search for Customer\n" + "\t3) Show Game Store Locations\n" + "\t4) Place An Order\n" + "\t5) List Of All Games\n" + "\t6) Quit?");

            int uChoice = int.Parse(Console.ReadLine());

            
                switch (uChoice)
                {
                case 1:
                    Console.WriteLine("\n");
                    StoreCustomer.addCustomer(ctx);
                    Thread.Sleep(600);
                    Console.WriteLine("\n\n");
                    promtUserMenu(ctx);
                    break;

                    case 2:
                    Console.WriteLine("\n");
                    CustLookUp.customerSearch(ctx);
                    Thread.Sleep(600);
                    Console.WriteLine("\n\n");
                    promtUserMenu(ctx);
                    break;

                    case 3:
                    Console.WriteLine("\n");
                    storeLocation.showLocation(ctx);
                    Thread.Sleep(600);
                    Console.WriteLine("\n\n");
                    promtUserMenu(ctx);
                    break;

                    case 4:
                    Console.WriteLine("\n");
                    Console.WriteLine("Are you a registered customer? (y/n)");
                    placeOrders.buyGame(ctx);
                    Thread.Sleep(600);
                    Console.WriteLine("\n\n");
                    promtUserMenu(ctx);
                    break;

                    case 5:
                    var listOfGames = new gameList();
                    Console.WriteLine("\n");
                    listOfGames.gameInventory();
                    Console.WriteLine("\n\n");
                    promtUserMenu(ctx);
                    break;

                    case 6:
                        System.Environment.Exit(0);
                        break;

                case 7:
                    ProductInventory.storeInventory();
                    promptUser.promtUserMenu(ctx);
                    break;

                    default:
                    Console.WriteLine("\n");
                    Console.WriteLine("You must choose an option from the list!");
                        promtUserMenu(ctx);
                        break;
                }
            
        }

    }
}
