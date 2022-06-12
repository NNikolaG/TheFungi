using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theFungiApplication.DataTransfer
{
    public class ItemsDto
    {
        public string Title { get;set; }
        public string Image { get; set; }
        public string Model { get; set; }
        public string CollectionName { get; set; }
        public IEnumerable<object> CollectionItemInfos { get; set; } = new HashSet<object>();
    }
}
