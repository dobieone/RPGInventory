using System.Collections.Generic;
using System.Linq;

namespace MD.Game.Inventory.Modifiers
{
    public class ModifierDB : List<ModifierProfile>
    {
        public ModifierProfile this[string id] { get => this.Where(n => n.ID == id).FirstOrDefault(); }
    }
}
