using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.Commands;
using theFungiApplication.Exceptions;
using theFungiDataAccess;
using theFungiDomain;

namespace theFungiImplementation.Commands
{
    public class EFDeleteGroupCommand : IDeleteGroupCommand
    {
        private readonly theFungiDbContext _db;

        public EFDeleteGroupCommand(theFungiDbContext db)
        {
            _db = db;

        }
        public int Id => 2;

        public string Name => "Deleting Group";

        public void Execute(int request)
        {
            var group = _db.Group.Find(request);

            if (group == null)
            {
                throw new EntityNotFoundException(request, typeof(Group));
            }

            _db.Group.Remove(group);
            _db.SaveChanges();
        }
    }
}
