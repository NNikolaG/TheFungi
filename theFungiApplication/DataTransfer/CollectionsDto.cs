using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiDomain.Entities;

namespace theFungiApplication.DataTransfer
{
    public class CollectionsDto
    {
        public string Title { get; set; }
        public string Username { get; set; }
        public string Category { get; set; }
        public IEnumerable<Object> Items { get; set; } = new HashSet<Object>();
    }
}
