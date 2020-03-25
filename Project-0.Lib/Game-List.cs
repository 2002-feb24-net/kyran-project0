using System;
using System.Linq;
using Project_0.Lib.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public  class gameList : IGameList
    {

        public  void gameInventory()
        {
            var ctx = new Game_RealmContext();
            List<Games> listOfGames = ctx.Games.ToList();
            foreach(var item in listOfGames)
            {
                Console.WriteLine("Title: " + item.Title + "\nGenre: " + item.Genre + "\nRelease Date: " + item.Release + "\nPrice: " + "$" + item.Price + "\n\n");
            }
        }

    }
}
