using MD.Game.Data;
using MD.Game.Inventory.Enums;

namespace MD.Game.Inventory.Modifiers
{
    public class ModifierProfile : DataObject
    {
        private Modifies _modifies;

        public Modifies Modifies
        {
            get { return _modifies; }
            set { _modifies = value; }
        }

        public ModifierProfile(string name) : base(name) { }
        public ModifierProfile(string id, string name) : base(id, name) { }
    }
}
