using MD.Game.Inventory.Items;
using System;

namespace MD.Game.Inventory.Events
{
    public class InventoryChangedEventArgs : EventArgs
    {
        private readonly int _amount;
        private readonly ItemProfile _profile;
        private readonly InventoryChangedEventType _type;
        public InventoryChangedEventArgs(InventoryChangedEventType type, int amount, ItemProfile profile)
        {
            _type = type;
            _amount = amount;
            _profile = profile;
        }

        public virtual InventoryChangedEventType Type
        {
            get => _type;
        }
        public virtual int Amount
        {
            get => _amount;
        }

        public virtual ItemProfile Profile
        {
            get =>_profile;
        }
    }
}
