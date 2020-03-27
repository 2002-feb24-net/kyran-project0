using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project_0.Lib.Entities;

namespace Store
{
    public static class ProductInventory 
    {
        public static void storeInventory(Game_RealmContext ctx)
        {
            var sInventory = from sales in ctx.Games
                            join products in ctx.Inventory on sales.Title equals products.Title
                            select (products);

            var prodList = ctx.Inventory.Include("Store").ToList();


            List<Inventory> listOfGames = ctx.Inventory.ToList();
            foreach (var item in prodList)
            {
                Console.WriteLine($"Store: {item.Store.StoreName}\tTitle: {item.Title}\tQuantity: {item.Quantity}\n");
            }
        }
    }
}
