using MD.Game.Inventory.Enums;
using MD.Game.Inventory.Items;
using MD.Game.Inventory.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.Game.Data
{
    public class CreateModifiers
    {
        private List<ModifierProfile> _modifiers;

        public List<ModifierProfile> Create()
        {
            _modifiers = new List<ModifierProfile>();

            var attack = new ModifierProfile("Attack", "Attack")
            {
                Modifies = Modifies.Attack,
            };
            _modifiers.Add(attack);

            var defence = new ModifierProfile("Defence", "Defence")
            {
                Modifies = Modifies.Defence,
            };
            _modifiers.Add(defence);

            var damage = new ModifierProfile("Damage", "Damage")
            {
                Modifies = Modifies.Damage,
            };
            _modifiers.Add(damage);

            var health = new ModifierProfile("Health", "Health")
            {
                Modifies = Modifies.Health,
            };
            _modifiers.Add(health);


            return _modifiers;
        }
    }
}