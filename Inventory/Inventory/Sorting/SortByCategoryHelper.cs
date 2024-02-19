using System.Collections.Generic;

namespace MD.Game.Inventory.Sorting
{
    public class SortByCategoryHelper : IComparer<InventoryItem>
    {
        public int Compare(InventoryItem x, InventoryItem y)
        {
            if ((int)x.Profile.Category > (int)y.Profile.Category)
                return 1;

            if ((int)x.Profile.Category < (int)y.Profile.Category)
                return -1;

            else
                return 0;
        }
    }
}
