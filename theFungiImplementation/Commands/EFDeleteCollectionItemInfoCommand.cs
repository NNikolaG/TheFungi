using Microsoft.EntityFrameworkCore;
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
    public class EFDeleteCollectionItemInfoCommand : IDeleteCollectionItemInfoCommand
    {
        private readonly theFungiDbContext _db;
        private readonly IApplicationActor _actor;

        public EFDeleteCollectionItemInfoCommand(theFungiDbContext db, IApplicationActor actor)
        {
            _actor = actor;
            _db = db;
        }
        public int Id => 33;

        public string Name => "Delete Collection Item Info";

        public void Execute(int request)
        {

            var info = _db.CollectionItemInfos.Include(x=>x.CollectionItem).Where(x=>x.Id == request).FirstOrDefault();

            if (info == null)
            {
                throw new EntityNotFoundException(request, typeof(CollectionItemInfos));
            }

            var userCollectionItem = _db.Collections.Any(x=>x.Id == info.CollectionItem.CollectionId && x.UserId == _actor.Id);

            if (!userCollectionItem)
            {
               throw new KeyCombinationNotFoundException(_actor.Id, typeof(Users), info.CollectionItem.CollectionId, typeof(Collections));
            }

            _db.CollectionItemInfos.Remove(info);
            _db.SaveChanges();
        }
    }
}
