using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theFungiApplication.UseCases.DataTransfer.Searches
{
    public class SearchDto : PagedSearch
    {
        public string Keyword { get; set; }
    }
}
