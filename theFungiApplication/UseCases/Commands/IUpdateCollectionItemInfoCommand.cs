using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.DataTransfer;

namespace theFungiApplication.UseCases.Commands
{
    public interface IUpdateCollectionItemInfoCommand : ICommand<CollectionItemInfoCreateDto>
    {
    }
}
