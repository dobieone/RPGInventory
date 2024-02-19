using System.Collections.Generic;
using System.Linq;

namespace MD.Tags
{
    public class TagDB : List<Tag>
    {
        public Tag this[string id] { get => this.Where(t => t.ID == id).FirstOrDefault(); }
    }
}
