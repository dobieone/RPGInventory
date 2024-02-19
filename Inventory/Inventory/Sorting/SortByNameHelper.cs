using System.Collections.Generic;

namespace MD.Game.Inventory.Sorting
{
    public class SortByNameHelper : IComparer<InventoryItem>
    {
        public int Compare(InventoryItem x, InventoryItem y)
        {
            return string.Compare(x.Profile.Name, y.Profile.Name);
        }
    }
}
