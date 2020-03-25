using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project_0.Lib.Entities;

namespace Store
{
    public static class ProductInventory 
    {
        public static void storeInventory()
        {
            var ctx = new Game_RealmContext();
            List<Inventory> listOfGames = ctx.Inventory.ToList();
            foreach (var item in listOfGames)
            {
                Console.WriteLine("StoreID  " + item.StoreId  +"\nQuantity" + item.Quantity +"\n\n");
            }
        }
    }
}
