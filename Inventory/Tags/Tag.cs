using MD.Game.Data;
using System;

namespace MD.Tags
{
    public class Tag : DataObject, IEquatable<Tag>
    {
        private bool _visible = true;
        private int _displayOrder = 1000;

        public bool Visible
        {
            get => _visible;
            set => _visible = value;
        }

        public int DisplayOrder
        {
            get => _displayOrder;
            set => _displayOrder = value;
        }

        public Tag(string name) : base(name) { }
        public Tag(string id, string name) : base(id, name) { }
        public bool Equals(Tag other) => ID == other.ID;
    }

}
