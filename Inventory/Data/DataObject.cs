using MD.Helpers;
using System;

namespace MD.Game.Data
{
    public class DataObject : IEquatable<DataObject>
    {
        private string _id;
        private string _name;

        public string ID
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public DataObject(string id, string name)
        {
            _id = id;
            _name = name;
        }

        public DataObject(string name)
        {
            _id = name.RemoveSpecialChars();
            _name = name;
        }

        public override string ToString() => $"{_id}, {_name}";
        public bool Equals(DataObject other) => _id == other.ID;

    }
}
