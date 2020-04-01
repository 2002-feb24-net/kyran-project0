using System;
using GameRealm.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameRealm
{
    public static class storeLocation
    {

        
        public static void showLocation(Game_RealmContext ctx)
        {
            List<Locations> locations_list = ctx.Locations.ToList();
            foreach (var item in locations_list)
            {
                Console.WriteLine("GameRealm Name: " + item.StoreName + "\nPhone Number: " + item.Phone + "\nE-Mail: " + item.Email + "\nStreet: " + item.Street + "\nCity: " + item.City + "\nState: " + item.State + "\nZipCode: " + item.ZipCode + "\nStoreID: " + item.StoreId + "\n\n" );
            }

        }

    }
}
