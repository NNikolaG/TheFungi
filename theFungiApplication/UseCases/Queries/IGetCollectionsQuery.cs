using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.DataTransfer;
using theFungiApplication.UseCases;
using theFungiApplication.UseCases.DataTransfer.Searches;

namespace theFungiApplication.Queries
{
    public interface IGetCollectionsQuery : IQuery<CollectionSearch, PageResponse<CollectionsDto>>
    {

    }
}
