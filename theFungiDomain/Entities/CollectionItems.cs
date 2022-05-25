using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theFungiDomain.Entities
{
    public class CollectionItems : Entity
    {
        public string Image { get; set; }
        public string? Model { get; set; }
        public int CollectionId { get; set; }
        public Collections Collection { get; set; }
        public ICollection<CollectionItemInfos> CollectionItemInfos { get; set; } = new HashSet<CollectionItemInfos>();

    }
}
