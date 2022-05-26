using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theFungiApplication.DataTransfer
{
    public class CollectionCreateDto
    {
        public string Title { get;set; }
        public int CategoryId { get; set; }
        public string BackgroundImage { get; set; }
        public int UserId { get; set; }
        
    }
}
