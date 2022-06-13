using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.UseCases.DataTransfer;
using theFungiApplication.UseCases.DataTransfer.Searches;

namespace theFungiApplication.UseCases.Queries
{
    public interface IGetLogsQuery : IQuery<LogSearchDto, IEnumerable<LogDto>>
    {
    }
}
