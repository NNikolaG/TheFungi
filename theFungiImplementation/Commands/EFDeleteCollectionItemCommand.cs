using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication;
using theFungiApplication.Exceptions;
using theFungiApplication.UseCases.Commands;
using theFungiDataAccess;
using theFungiDomain.Entities;

namespace theFungiImplementation.Commands
{
    public class EFDeleteCollectionItemCommand : IDeleteCollectionItemCommand
    {
        private readonly theFungiDbContext _db;
        private readonly IApplicationActor _actor;
        public EFDeleteCollectionItemCommand(theFungiDbContext db, IApplicationActor actor)
        {
            _actor = actor;
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

            var userCollection = _db.Collections.Any(x => x.UserId == _actor.Id && x.Id == item.CollectionId);

            if (!userCollection)
            {
                throw new KeyCombinationNotFoundException(_actor.Id, typeof(Users), item.CollectionId, typeof(Collections));
            }

            var infos = _db.CollectionItemInfos.Where(x => x.CollectionItemId == request).ToList();
            _db.CollectionItemInfos.RemoveRange(infos);

            _db.CollectionItems.Remove(item);
            _db.SaveChanges();
        }
    }
}
