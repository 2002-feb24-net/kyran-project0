using System;
using System.Linq;
using GameRealm.DAL.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GameRealm
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
