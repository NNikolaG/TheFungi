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
    public class EFDeleteCollectionCommand : IDeleteCollectionCommand
    {
        private readonly theFungiDbContext _db;

        public EFDeleteCollectionCommand(theFungiDbContext db)
        {
            _db = db;
        }
        public int Id => 17;

        public string Name => "Delete Collection Command";

        public void Execute(int request)
        {
            var collection = _db.Collections.Find(request);
            var follows = _db.Follows.Where(x => x.CollectionId == request).ToList();

            if (collection == null)
            {
                throw new EntityNotFoundException(request, typeof(Collections));
            }

            _db.Follows.RemoveRange(follows);
            _db.Collections.Remove(collection);
            _db.SaveChanges();
        }
    }
}
