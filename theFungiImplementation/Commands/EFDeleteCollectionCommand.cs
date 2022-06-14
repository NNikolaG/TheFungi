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
    public class EFDeleteCollectionCommand : IDeleteCollectionCommand
    {
        private readonly theFungiDbContext _db;
        private readonly IApplicationActor _actor;

        public EFDeleteCollectionCommand(theFungiDbContext db, IApplicationActor actor)
        {
            _db = db;
            _actor = actor;
        }
        public int Id => 17;

        public string Name => "Delete Collection Command";

        public void Execute(int request)
        {
            var collection = _db.Collections.Where(x=>x.UserId == _actor.Id && x.Id == request).FirstOrDefault();

            if (collection == null)
            {
                throw new EntityNotFoundException(request, typeof(Collections));
            }
            var follows = _db.Follows.Where(x => x.CollectionId == request).ToList();

            _db.Follows.RemoveRange(follows);
            _db.Collections.Remove(collection);
            _db.SaveChanges();
        }
    }
}
