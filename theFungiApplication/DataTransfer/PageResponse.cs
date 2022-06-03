using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theFungiApplication.DataTransfer
{
    public class PageResponse<T> where T : class, new()
    {
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int PagesCount => (int)Math.Ceiling((float)TotalCount / PerPage);
        public IEnumerable<T> Data { get; set; }
    }
}
