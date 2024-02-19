using MD.Game.Inventory.Exceptions;
using MD.Game.Inventory.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MD.Game.Inventory.Items;

namespace MD.Game.Inventory
{
    public class InventoryManager : IEnumerable<InventoryItem>
    {
        private readonly InventoryItem _default = new InventoryItem() { Amount = 0, Profile = null};
		private List<InventoryItem> _items;

        public event EventHandler<InventoryChangedEventArgs> InventoryChanged;

        public InventoryManager()
        {
            _items = new List<InventoryItem>();
        }
        
        public List<InventoryItem> Items => _items;

        public InventoryItem this[int index]
        {
            get => _items[index];
        }

        public int Count { get => _items.Count; }
        public void Clear()
        {
            _items.Clear();
            OnInventoryChanged(InventoryChangedEventType.Clear, 0, null);
        }

        public void Add(ItemProfile profile, int amount = 1)
        {
            var total = amount;
            var items = Get(profile);

            InventoryItem item = null;

            if (items.Count > 0)
                item = items.Where(i => i.Amount < i.Profile.MaxStack).FirstOrDefault();

            while (total > 0)
            {
                if (item != null)
                {
                    var max = item.Profile.MaxStack;
                    var current = item.Amount;
                    var add = 0;

                    if (current + total > max)
                        add = max - current;
                    else
                        add = amount;

                    total -= add;
                    item.Amount += add;
                    item.Seen = false;
                    item.AddedOn = DateTime.Now;

                    OnInventoryChanged(InventoryChangedEventType.Increase, add, item);
                    item = null;

                }

                if (total > 0)
                {
                    var add = AddNewItem(profile, total);
                    total -= add;
                }
            }
        }

        private int AddNewItem(ItemProfile item, int amount)
        {
            var add = amount <= item.MaxStack ? amount : item.MaxStack;

            var ni = new InventoryItem
            {
                Profile = item,
                Amount = add,
                Seen = false,
                AddedOn = DateTime.Now
            };

            _items.Add(ni);

            OnInventoryChanged(InventoryChangedEventType.Add, add, ni);

            return add;
        }

        public void Remove(ItemProfile profile, int amount = 1)
        {
            var items = Get(profile);
            var available = items.Sum(v => v.Amount);
         
            if (available < amount)
            {
                throw new InventoryInsufficientAmountException("Insufficient Amount", available, amount);
            }

            var sorted = items.OrderBy(v => v.Amount);
            var total = amount;

            foreach (var item in sorted)
            {
                if (item.Amount > total)
                {
                    item.Amount -= total;
                    OnInventoryChanged(InventoryChangedEventType.Decrease, total, item);
                    return;
                }
                else
                {
                    total -= item.Amount;
                    if (item.Profile.RemoveFromInventory || RemoveFromItemList(item))
                    {
                        OnInventoryChanged(InventoryChangedEventType.Remove, item.Amount, item);
                        _items.Remove(item);
                    }
                    else
                    {
                        OnInventoryChanged(InventoryChangedEventType.Decrease, item.Amount, item);
                        item.Amount = 0;
                    }
                }
            }
        }

        private bool RemoveFromItemList(InventoryItem item)
        {
            return Contains(item.Profile, item.Amount + 1);
        }

        public bool Contains(ItemProfile item, int amount)
        {
            var items = Get(item);
            var total = items.Sum(v => v.Amount);
            return total >= amount;
        }

        public void MarkAsSeen(InventoryItem item) => item.Seen = true;        

        #region Sorting
        public void Sort(IComparer<InventoryItem> comparer)
        {
            _items.Sort(comparer);
        }
        #endregion

        private List<InventoryItem> Get(ItemProfile item)
        {
            var rtn = _items.Where(i => i.Profile == item).ToList();
            return rtn;
        }

        protected void OnInventoryChanged(InventoryChangedEventType type, int amount, InventoryItem item)
        {
            InventoryChanged?.Invoke(this, new InventoryChangedEventArgs(type, amount, item.Profile));
        }

        public IEnumerator<InventoryItem> GetEnumerator() => _items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
