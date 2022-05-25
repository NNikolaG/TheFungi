using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theFungiDomain.Entities
{
    public class Follow
    {
        public int CollectionId { get; set; }
        public virtual Collections Collection { get; set; }
        public int UserId { get; set; }
        public virtual Users User { get; set; }
    }
}
