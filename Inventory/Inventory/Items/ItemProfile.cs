using MD.Game.Data;
using MD.Game.Inventory.Modifiers;
using MD.Tags;

namespace MD.Game.Inventory.Items
{
    public class ItemProfile : DataObject
    {
        private TagManager _tags = new TagManager();
        private ModifierManager _modifiers = new ModifierManager();
        private ItemCategories _category;
        private bool _stackable = true;
        private int _maxStack = int.MaxValue;
        private bool _removeFromInventory = true;
        private int _value;
        private string _description;

        public TagManager Tags
        {
            get { return _tags; }
            set { _tags = value; }
        }

        public ModifierManager Modifiers
        {
            get { return _modifiers; }
            set { _modifiers = value; }
        }

        public ItemCategories Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public bool Stackable
        {
            get { return _stackable; }
            set {
                if (value == false)
                    _maxStack = 1;
                _stackable = value; 
            }
        }
        
        public int MaxStack
        {
            get { return _maxStack; }
            set { _maxStack = value; }
        }

        public bool RemoveFromInventory
        {
            get { return _removeFromInventory; }
            set { _removeFromInventory = value; }
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public ItemProfile(string name) : base(name) 
        {
            _description = name; 
        
        }
        public ItemProfile(string id, string name) : base(id, name) 
        {
            _description = name; 
        }

    }
}
