using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.DataTransfer;
using theFungiApplication.UseCases;
using theFungiApplication.UseCases.DataTransfer;
using theFungiApplication.UseCases.DataTransfer.Searches;
using theFungiApplication.UseCases.Queries;
using theFungiDataAccess;

namespace theFungiImplementation.Queries
{
    public class EFGetLogsQuery : IGetLogsQuery
    {
        private readonly theFungiDbContext _db;
        public EFGetLogsQuery(theFungiDbContext db)
        {
            _db = db;
        }

        public int Id => 1;

        public string Name => "Get Logs";

        public PageResponse<LogDto> Execute(LogSearchDto search)
        {
            var logsQ = _db.AuditLogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                logsQ = logsQ.Where(x => x.Identity.ToLower().Contains(search.Keyword.ToLower()) || x.Command.ToLower().Contains(search.Keyword.ToLower()));
            }

            if (search.From.HasValue)
            {
                logsQ = logsQ.Where(x => x.PerformedAt > search.From);
            }

            if (search.To.HasValue)
            {
                logsQ = logsQ.Where(x => x.PerformedAt < search.To);
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var data = new PageResponse<LogDto>
            {
                Page = search.Page,
                PerPage = search.PerPage,
                TotalCount = logsQ.Count(),
                Data = logsQ.Skip(skipCount).Take(search.PerPage).Select(x => new LogDto
                {
                    UseCase = x.Command,
                    Identity = x.Identity,
                    PerformedAt = x.PerformedAt
                }).ToList()
            };

            return data;
        }
    }
}
