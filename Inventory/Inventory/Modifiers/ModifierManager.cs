using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MD.Game.Inventory.Modifiers
{
    public class ModifierManager : IEnumerable<Modifier>
    {
        private readonly Modifier _default = new Modifier(null, 0);
        private List<Modifier> _modifiers = new List<Modifier>();

        public List<Modifier> All { get => _modifiers; }

        public Modifier this[int index]
        {
            get => _modifiers[index];
            set => _modifiers[index] = value;
        }

        public ModifierManager()
        {
            _modifiers = new List<Modifier>();
        }

        public Modifier this[string name] { get => _modifiers.Where(n => n.Profile.Name == name).FirstOrDefault(); }

        public void Add(Modifier modifier)
        {
            if (!Contains(modifier))
                _modifiers.Add(modifier);
        }

        public bool Contains(Modifier modifier) => _modifiers.Contains(modifier);
        public bool HasTag(Modifier modifier) => _modifiers.Contains(modifier);
        public void Remove( Modifier modifier) => _modifiers.Remove(modifier);
        public int Count => _modifiers.Count;
        public void Clear() => _modifiers.Clear();
        public IEnumerator<Modifier> GetEnumerator() => _modifiers.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
