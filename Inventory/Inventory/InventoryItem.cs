using MD.Game.Inventory.Items;
using System;

namespace MD.Game.Inventory
{
    public class InventoryItem
    {
		private ItemProfile _profile;
        private int _amount;
		private bool _seen = false;
        private DateTime _addedOn;

		public ItemProfile Profile
		{
			get { return _profile; }
			set { _profile = value; }
		}
		
		public int Amount
		{
			get { return _amount; }
			set { _amount = value; }
		}

        public bool Seen
        {
            get { return _seen; }
            set { _seen = value; }
        }
        public DateTime AddedOn
        {
            get { return _addedOn; }
            set { _addedOn = value; }
        }

        public override string ToString()
        {
   //         var tags = _profile.Tags.Select(s => s.Name).ToArray();
			//var t = string.Join(", ", tags);
            return $"{_profile.Name, -10} x{_amount} at {_profile.Value:N0}c";
        }

    }
}
