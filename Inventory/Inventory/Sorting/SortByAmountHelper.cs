using System.Collections.Generic;

namespace MD.Game.Inventory.Sorting
{
    public class SortByAmountHelper : IComparer<InventoryItem>
    {
        public int Compare(InventoryItem x, InventoryItem y)
        {
            if (x.Amount > y.Amount)
                return 1;

            if (x.Amount < y.Amount)
                return -1;

            else
                return 0;
        }
    }
}
