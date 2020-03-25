using System;
using System.Linq;
using System.Text;
using Project_0.Lib.Entities;
using System.Threading;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Store
{
    class placeOrders : IGameList
    {
        public static void buyGame(Game_RealmContext ctx)
        {


           
            var choice = Console.ReadLine();

            if (choice.ToUpper() == "Y")
            {
                CustStorage.custLogin(ctx);


            }

            else if (choice.ToUpper() == "N")
            {
                Console.WriteLine("You must be a user to place orders!\n");
                Thread.Sleep(800);
                Console.WriteLine("Please Login or Create a new account!\n");
                    //Dont allow purchase until confirmation that they are registered with us.
                    promptUser.promtUserMenu(ctx);
            }
            else if(choice == "")
            {
                Console.WriteLine("You Must Enter something !\n");
                Thread.Sleep(800);
                Console.WriteLine("Please Login or Create a new account!\n");
                //Dont allow purchase until confirmation that they are registered with us.
                promptUser.promtUserMenu(ctx);
            }
            else
            {
                Console.WriteLine("Invalid Entry!\n");
                Thread.Sleep(800);
                Console.WriteLine("Please Login or Create a new account!\n");
                //Dont allow purchase until confirmation that they are registered with us.
                promptUser.promtUserMenu(ctx);
            }

            int nums = 1;
            string parenth = ")";

            Console.WriteLine("Which store location would you like to purchase your game from?\n");
            Thread.Sleep(800);

            List<Locations> locations_list = ctx.Locations.ToList();


            foreach (var item in locations_list)
            {
                Console.WriteLine(nums + parenth + " Store Name: " + item.StoreName + "\nStreet: " + item.Street + "\nCity: " + item.City + "\nState: " + item.State + "\n\n");
                nums++;
            }

            
            int uInput = int.Parse(Console.ReadLine());
            /*var storeID = ctx.Locations.FirstOrDefault(sid => sid.StoreId == uInput);*/



            switch (uInput)
            {
                case 1:
                    Console.WriteLine("\n");
                    Console.WriteLine("Your store: Long Beach, Ca\n");
                    Thread.Sleep(700);
                    break;

                case 2:
                    Console.WriteLine("\n");
                    Console.WriteLine("Your store: Miami, Fl\n");
                    Thread.Sleep(700);
                    break;

                case 3:
                    Console.WriteLine("\n");
                    Console.WriteLine("Your store: New York, Ny\n");
                    Thread.Sleep(700);
                    break;

                case 4:
                    Console.WriteLine("\n");
                    Console.WriteLine("Your store: Dallas, Tx\n");
                    Thread.Sleep(700);
                    break;

                default:
                    Console.WriteLine("\n");
                    Console.WriteLine("Incorrect input, you must choose a store location!\n\n");
                    Thread.Sleep(700);
                    Console.WriteLine("Are you a registered customer? (y/n)");
                    buyGame(ctx);
                    break;
            }

            List<Games> orderTotal = new List<Games>();

            var showInventory = new placeOrders();
            Console.WriteLine("Choose a game that you would you like to buy, based on GameID: \n\n");
            Thread.Sleep(900);
            showInventory.gameInventory();
            Thread.Sleep(800);
            Console.WriteLine("Choose GameID: ");
            int gameChoice = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");

            var gameID = ctx.Games.FirstOrDefault(gChoice => gChoice.ProductId == gameChoice);


            if (gameID != null)
            {
                /*string uInput = "";*/


                Console.WriteLine($"You have chosen:\nGame Title: {gameID.Title} \nPrice: ${gameID.Price}\n");
                
                Console.WriteLine("add another game to your cart? (y/n)");
                string answer = Console.ReadLine();
                while (answer.ToUpper() == "Y")
                {
                    int count = 1;
                    Console.WriteLine("Choose GameID: ");
                    int gameChoice2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n");
                    var gameID2 = ctx.Games.FirstOrDefault(gChoice => gChoice.ProductId == gameChoice2);
                    orderTotal.Add(gameID2);

                    foreach (var item in orderTotal)
                    {
                        count++;
                    }
                    Thread.Sleep(1000);
                    Console.WriteLine($"You have chosen:\nGame Title: {gameID2.Title} \nPrice: ${gameID2.Price}\n");
                    Console.WriteLine(count + " Games in your cart!\n");

                    Console.WriteLine("\nadd another game to your cart? (y/n)");
                    string answer2 = Console.ReadLine();
                    if (answer2.ToUpper() == "N")
                    {   

                        return;
                    }
                    
                }



               
                
                    
                


                Console.WriteLine("Would you like to confirm your Purchase? (y/n)");
                var uChoice = Console.ReadLine();


                if (uChoice.ToUpper() == "Y")
                {
                    DateTime orederTime = DateTime.Now;
                    Orders order = new Orders()
                    {
                        /*StoreId = ctx.Locations.Find(storeID) ,
                        CustomerId = id,*/
                        Checkout = gameID.Price,
                        Time = DateTime.Now
                    };
                    ctx.Orders.Add(order);
                    ctx.SaveChanges();

                    Console.WriteLine("Thank you for your purchase!");
                }




                else if (uChoice.ToUpper() == "N")
                {
                    

                    Console.WriteLine("Ok, Well what would you like to do?");
                    Thread.Sleep(800);
                    Console.WriteLine("1) Main Menu\t\t2) Purchase a Game");
                    int userChoice = int.Parse(Console.ReadLine());

                    switch (userChoice)
                    {
                        case 1:
                            Console.WriteLine("\n");
                            promptUser.promtUserMenu(ctx);
                            Thread.Sleep(600);
                            break;

                        case 2:
                            Console.WriteLine("\n");
                            placeOrders.buyGame(ctx);
                            Thread.Sleep(600);
                            break;
                    }

                }

            }


            else
            {
                Console.WriteLine("Invalid GameID! Please choose The proper GameID from the list of Games Shown.");
                Console.WriteLine("Are you a registered customer? (y/n)");
                placeOrders.buyGame(ctx);
            }





        }

        public void gameInventory()
        {
            var ctx = new Game_RealmContext();
            List<Games> listOfGames = ctx.Games.ToList();
            foreach (var item in listOfGames)
            {
                Console.WriteLine("GameID: " + item.ProductId + "\nTitle: " + item.Title + "\nGenre: " + item.Genre + "\nRelease Date: " + item.Release + "\nPrice: " + "$" + item.Price + "\n\n");
            }
        }

    }
}
