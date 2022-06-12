using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication;
using theFungiApplication.Loggers;
using theFungiApplication.UseCases;
using theFungiDataAccess;
using theFungiDomain.Entities;

namespace theFungiImplementation.Loggers
{
    public class Logger : IUseCaseLogger
    {
        private readonly theFungiDbContext _db;

        public Logger(theFungiDbContext db)
        {
            _db = db;
        }

        public void Log(IUseCase usecase, IApplicationActor actor, object usecaseData)
        {
            var data = $"{JsonConvert.SerializeObject(usecaseData)}";

            var log = new AuditLog
            {
                Command = usecase.Name,
                Identity = actor.Identity,
                Data = data,
                PerformedAt = DateTime.UtcNow
            };

            _db.AuditLogs.Add(log);
            _db.SaveChanges();
        }
    }
}
