using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.DataTransfer;

namespace theFungiApplication.Queries
{
    public interface IGetSingleCollectionItemQuery : IQuery<int, ItemsDto>
    {
    }
}
