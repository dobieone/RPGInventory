using MD.Tags;
using System.Collections.Generic;

namespace MD.Game.Data
{
    internal class CreateTags
    {
        private List<Tag> _tags;

        public List<Tag> Create()
        {

            _tags = new List<Tag>
            {
                new Tag("Weapon"),
                new Tag("One Handed"),
                new Tag("Clothing"),
                new Tag("Consumable"),
                new Tag("Drink"),
                new Tag("Food"),
                new Tag("Healing"),
                new Tag("Junk"),
                new Tag("Currency"),
            };
            return _tags;
       }
    }
}
