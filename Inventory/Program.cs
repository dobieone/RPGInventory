using MD.Game.Data;
using MD.Game.Inventory;
using MD.Game.Inventory.Events;
using MD.Game.Inventory.Exceptions;
using MD.Game.Inventory.Items;
using MD.Game.Inventory.Sorting;
using System;
using System.Linq;

namespace MD.Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = new Database();
            var items = data.Items;

            var i = new InventoryManager();
            i.InventoryChanged += OnInventoryChanged;

            var potion = items["Potion"];

            Console.WriteLine(" * CALLBACKS");
            i.Add(items["Sword"]);
            i.Add(items["Coat"]);
            i.Add(potion);
            i.Add(potion);
            i.Add(potion, 5);
            i.Add(items["Apple"], 3);
            i.Add(items["Water"], 2);
            i.Add(items["Scrap"]);
            i.Add(items["Coins"], 1000);

            i.Remove(potion, 3);
            i.Remove(items["Coins"], 999);
            i.Remove(items["Coins"], 1);
            i.Remove(items["Scrap"], 1);

            try
            {
                i.Remove(potion, 10);
            }
            catch (InventoryInsufficientAmountException e)
            {
                Console.WriteLine();
                Console.WriteLine($"EXCEPTION: {e.Message}, {e.Required} vs {e.Available}");
            }

            var s = new SortByCategoryHelper();
            i.Sort(s);

            Console.WriteLine();
            Console.WriteLine(" * INVENTORY");
            foreach (var ii in i.Items.Where(ii => ii.Profile.Category != ItemCategories.Currency))
            {
                Console.WriteLine(ii);
            }

            Console.WriteLine();
            Console.WriteLine(" * CONSUMABLES");
            foreach (var ii in i.Items.Where(ii => ii.Profile.Category == ItemCategories.Consumable))
            {
                Console.WriteLine(ii);
            }

            Console.WriteLine();
            Console.WriteLine(" * CURRENCIES");
            foreach (var ii in i.Items.Where(ii => ii.Profile.Category == ItemCategories.Currency))
            {
                Console.WriteLine(ii);
            }

            Console.WriteLine();
            Console.WriteLine(" * CONTAINS");
            Console.WriteLine($"Contains {potion.Name} x4 = {i.Contains(potion, 4)}");
            Console.WriteLine($"Contains {potion.Name} x6 = {i.Contains(potion, 6)}");


            var sword = items["Sword"];
            Console.WriteLine();
            Console.WriteLine($" * {sword.Name.ToUpper()}");
            Console.WriteLine($"{sword.Description}");
            Console.WriteLine($"Value:     {sword.Value}");
            Console.WriteLine($"Category:  {sword.Category}");
            Console.WriteLine($"Stackable: {sword.Stackable}");
            Console.WriteLine($"Modifiers:");
            foreach (var mod in sword.Modifiers)
            {
                Console.WriteLine($" > {mod}");
            }
            
            Console.ReadKey();
        }

        private static void OnInventoryChanged(object sender, InventoryChangedEventArgs e)
        {
            Console.WriteLine($"{e.Type}: {e.Profile.Name} x{e.Amount}");
        }


    }
}
