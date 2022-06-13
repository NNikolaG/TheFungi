using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.Exceptions;
using theFungiApplication.UseCases.Commands;
using theFungiDataAccess;
using theFungiDomain.Entities;

namespace theFungiImplementation.Commands
{
    public class EFDeleteCollectionItemInfoCommand : IDeleteCollectionItemInfoCommand
    {
        private readonly theFungiDbContext _db;

        public EFDeleteCollectionItemInfoCommand(theFungiDbContext db)
        {
            _db = db;
        }
        public int Id => 33;

        public string Name => "Delete Collection Item Info";

        public void Execute(int request)
        {

            var info = _db.CollectionItemInfos.Find(request);

            if (info == null)
            {
                throw new EntityNotFoundException(request, typeof(CollectionItemInfos));
            }

            _db.CollectionItemInfos.Remove(info);
            _db.SaveChanges();
        }
    }
}
