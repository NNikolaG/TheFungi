using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication;
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
        private readonly IApplicationActor _actor;
        public EFDeleteFollowCommand(theFungiDbContext db, IApplicationActor actor)
        {
            _db = db;
            _actor = actor;
        }

        public int Id => 23;

        public string Name => "Delete Follow";

        public void Execute(int request)
        {
            var follow = _db.Follows.Where(x => x.UserId == _actor.Id && x.CollectionId == request).FirstOrDefault();

            if (follow == null)
            {
                throw new EntityNotFoundException(request, typeof(Follows));
            }

            _db.Follows.Remove(follow);
            _db.SaveChanges();
        }
    }
}
