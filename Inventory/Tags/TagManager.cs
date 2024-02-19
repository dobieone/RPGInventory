using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MD.Tags
{
    public class TagManager : IEnumerable<Tag>
    {
        private readonly Tag _default = new Tag(null, null);
        private List<Tag> _tags = new List<Tag>();

        public List<Tag> All { get => _tags; }

        public Tag this[int index]
        {
            get => _tags[index];
            set => _tags[index] = value;
        }

        public TagManager()
        {
            _tags = new List<Tag>();
        }

        public Tag this[string name] { get => _tags.Where(n => n.Name == name).FirstOrDefault(); }

        public void Add(Tag tag)
        {
            if (!Contains(tag))
                _tags.Add(tag);
        }

        public bool Contains(Tag tag) => _tags.Contains(tag);
        public bool HasTag(Tag tag) => _tags.Contains(tag);
        public void Remove(Tag tag) => _tags.Remove(tag);
        public int Count => _tags.Count;
        public void Clear() => _tags.Clear();
        public IEnumerator<Tag> GetEnumerator() => _tags.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
