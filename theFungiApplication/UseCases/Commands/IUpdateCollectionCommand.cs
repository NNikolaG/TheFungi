using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.DataTransfer;
using theFungiApplication.UseCases;

namespace theFungiApplication.Commands
{
    public interface IUpdateCollectionCommand : IQuery<int, CollectionCreateDto>
    {
    }
}
