using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theFungiDomain.Entities
{
    public class CollectionItemInfos : Entity
    {
        public string Content { get; set; }
        public int CollectionItemId { get; set; }
        public CollectionItems CollectionItem { get; set; }

    }
}
