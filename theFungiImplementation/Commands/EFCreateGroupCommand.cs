using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.Commands;
using theFungiApplication.DataTransfer;
using theFungiDataAccess;
using theFungiDomain;
using theFungiImplementation.Validators;

namespace theFungiImplementation.Commands
{
    public class EFCreateGroupCommand : ICreateGroupCommand
    {
        private readonly theFungiDbContext _db;
        private readonly CreateGroupValidator _validator;

        public EFCreateGroupCommand(theFungiDbContext db, CreateGroupValidator validator)
        {
            _validator = validator;
            _db = db;
        }
        public int Id => 1;

        public string Name => "Create New Group";

        public void Execute(GroupDto request)
        {
            _validator.ValidateAndThrow(request);

            var group = new Group
            {
                Name = request.Name,
            };

            _db.Group.Add(group);
            _db.SaveChanges();
        }
    }
}
