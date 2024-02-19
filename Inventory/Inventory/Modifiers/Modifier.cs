using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.Game.Inventory.Modifiers
{
    public class Modifier
    {
		private ModifierProfile _profile;
		private int _amount;
		
        public ModifierProfile Profile
		{
			get { return _profile; }
			set { _profile = value; }
		}

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public Modifier(ModifierProfile profile, int amount)
        {
            Profile = profile;
            Amount = amount;
        }

        public override string ToString()
        {
            string a = (_amount > 0 ? "+" : "");
            return $"{_profile.Name} {a}{_amount}";
        }
    }
}
