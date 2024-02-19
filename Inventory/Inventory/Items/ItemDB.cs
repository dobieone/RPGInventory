using System.Collections.Generic;
using System.Linq;

namespace MD.Game.Inventory.Items
{
    public class ItemDB : List<ItemProfile>
    {
        public ItemProfile this[string id] { get => this.Where(n => n.ID == id).FirstOrDefault(); }
    }
}
