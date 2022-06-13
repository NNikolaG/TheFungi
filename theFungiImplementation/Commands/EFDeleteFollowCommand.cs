using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.DataTransfer;
using theFungiApplication.Exceptions;
using theFungiApplication.UseCases.Commands;
using theFungiDataAccess;
using theFungiDomain.Entities;

namespace theFungiImplementation.Commands
{
    public class EFDeleteFollowCommand : IDeleteFollowCommand
    {
        private readonly theFungiDbContext _db;

        public EFDeleteFollowCommand(theFungiDbContext db)
        {
            _db = db;
        }
        public int Id => 23;

        public string Name => "Delete Follow";

        public void Execute(CreateFollowDto request)
        {
            var follow = _db.Follows.Where(x=>x.UserId == request.UserId && x.CollectionId == request.CollectionId).FirstOrDefault();

            if (follow == null)
            {
                throw new EntityNotFoundException(request.CollectionId, typeof(Follows));
            }

            _db.Follows.Remove(follow);
            _db.SaveChanges();
        }
    }
}
