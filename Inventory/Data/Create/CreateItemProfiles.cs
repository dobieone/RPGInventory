using MD.Game.Inventory.Items;
using MD.Game.Inventory.Modifiers;
using MD.Tags;
using System.Collections.Generic;

namespace MD.Game.Data
{
    public class CreateItemProfiles
    {
        private List<ItemProfile> _itemProfiles;

        public List<ItemProfile> Create(TagDB tags, ModifierDB modifiers)
        {
            _itemProfiles = new List<ItemProfile>();

            var sword = new ItemProfile("Sword");
            sword.Tags.Add(tags["Weapon"]);
            sword.Tags.Add(tags["OneHanded"]);
            sword.Category = ItemCategories.Weapon;
            sword.Stackable = false;
            sword.Value = 50;
            sword.Modifiers.Add(new Modifier(modifiers["Attack"], 5));
            sword.Modifiers.Add(new Modifier(modifiers["Damage"], 3));
            sword.Description = "A standard sword.";
            _itemProfiles.Add(sword);

            var axe = new ItemProfile("Axe");
            axe.Tags.Add(tags["Weapon"]);
            axe.Tags.Add(tags["OneHanded"]);
            axe.Category = ItemCategories.Weapon;
            axe.Stackable = false;
            axe.Value = 40;
            axe.Modifiers.Add(new Modifier(modifiers["Attack"], 3));
            axe.Modifiers.Add(new Modifier(modifiers["Damage"], 2));
            _itemProfiles.Add(axe);

            var coat = new ItemProfile("Coat");
            coat.Tags.Add(tags["Clothing"]);
            coat.Category = ItemCategories.Clothing;
            coat.Stackable = false;
            coat.Value = 15;
            coat.Modifiers.Add(new Modifier(modifiers["Defence"], 2));
            _itemProfiles.Add(coat);

            var leathers = new ItemProfile("Leathers");
            leathers.Tags.Add(tags["Clothing"]);
            leathers.Category = ItemCategories.Clothing;
            leathers.Stackable = false;
            leathers.Value = 20;
            leathers.Modifiers.Add(new Modifier(modifiers["Defence"], 5));
            _itemProfiles.Add(leathers);

            var potion = new ItemProfile("Potion");
            potion.Tags.Add(tags["Consumable"]);
            potion.Tags.Add(tags["Drink"]);
            potion.Tags.Add(tags["Healing"]);
            potion.Category = ItemCategories.Consumable;
            potion.MaxStack = 5;
            potion.Value = 25;
            potion.Modifiers.Add(new Modifier(modifiers["Health"], 50));
            _itemProfiles.Add(potion);

            var apple = new ItemProfile("Apple");
            apple.Tags.Add(tags["Consumable"]);
            apple.Tags.Add(tags["Food"]);
            apple.Category = ItemCategories.Consumable;
            apple.MaxStack = 5;
            apple.Value = 2;
            apple.Modifiers.Add(new Modifier(modifiers["Health"], 5));
            _itemProfiles.Add(apple);

            var water = new ItemProfile("Water");
            water.Tags.Add(tags["Consumable"]);
            water.Tags.Add(tags["Drink"]);
            water.Category = ItemCategories.Consumable;
            water.MaxStack = 2;
            water.Value = 5;
            water.Modifiers.Add(new Modifier(modifiers["Health"], 10));
            _itemProfiles.Add(water);

            var torch = new ItemProfile("Torch");
            torch.Tags.Add(tags["Junk"]);
            torch.Category = ItemCategories.Junk;
            torch.MaxStack = 4;
            torch.Value = 1;
            _itemProfiles.Add(torch);

            var scrap = new ItemProfile("Scrap");
            scrap.Tags.Add(tags["Junk"]);
            scrap.Category = ItemCategories.Junk;
            scrap.MaxStack = 2;
            scrap.Value = 1;
            _itemProfiles.Add(scrap);

            var coins = new ItemProfile("Coins");
            coins.Tags.Add(tags["Currency"]);
            coins.Category = ItemCategories.Currency;
            coins.RemoveFromInventory = false;
            coins.Value = 1;
            _itemProfiles.Add(coins);

            return _itemProfiles; 
        }
    }
}
