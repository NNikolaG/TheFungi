using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public IEnumerable<LogDto> Execute(LogSearchDto search)
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

            var logs = logsQ.ToList();

            var data = logs.Select(x => new LogDto
            {
                UseCase = x.Command,
                Identity = x.Identity,
                PerformedAt = x.PerformedAt
            });

            return data;
        }
    }
}
