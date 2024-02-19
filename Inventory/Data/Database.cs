using MD.Game.Inventory.Items;
using MD.Game.Inventory.Modifiers;
using MD.Tags;

namespace MD.Game.Data
{
    public class Database
    {
        public TagDB Tags { get; set; }
        public ItemDB Items { get; set; }

        public ModifierDB Modifiers { get; set; }

        public Database()
        {
            var ct = new CreateTags();
            Tags = new TagDB();
            Tags.AddRange(ct.Create());

            var cmp = new CreateModifiers();
            Modifiers = new ModifierDB();
            Modifiers.AddRange(cmp.Create());

            var cip = new CreateItemProfiles();
            Items = new ItemDB();
            Items.AddRange(cip.Create(Tags, Modifiers));

        }

    }
}
