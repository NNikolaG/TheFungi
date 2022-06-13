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
    public class EFDeleteCollectionItemCommand : IDeleteCollectionItemCommand
    {
        private readonly theFungiDbContext _db;

        public EFDeleteCollectionItemCommand(theFungiDbContext db)
        {
            _db = db;
        }

        public int Id => 28;

        public string Name => "Delete Collection Item Command";

        public void Execute(int request)
        {
            var item = _db.CollectionItems.Find(request);

            if(item == null)
            {
                throw new EntityNotFoundException(request, typeof(CollectionItems));
            }

            var infos = _db.CollectionItemInfos.Where(x => x.CollectionItemId == request).ToList();
            _db.CollectionItemInfos.RemoveRange(infos);

            _db.CollectionItems.Remove(item);
            _db.SaveChanges();
        }
    }
}
