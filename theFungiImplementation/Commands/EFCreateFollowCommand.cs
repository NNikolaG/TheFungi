using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication;
using theFungiApplication.Commands;
using theFungiApplication.DataTransfer;
using theFungiDataAccess;
using theFungiDomain.Entities;
using theFungiImplementation.Validators;

namespace theFungiImplementation.Commands
{
    public class EFCreateFollowCommand : ICreateFollowCommand
    {
        private readonly theFungiDbContext _db;
        private readonly CreateFollowValidator _validator;
        private readonly IApplicationActor _actor;

        public EFCreateFollowCommand(theFungiDbContext db, CreateFollowValidator validator, IApplicationActor actor)
        {
            _db = db;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 22;

        public string Name => "Create Follows";

        public void Execute(CreateFollowDto request)
        {
            _validator.ValidateAndThrow(request);

            var data = new Follows
            {
                UserId = _actor.Id,
                CollectionId = request.CollectionId
            };

            _db.Follows.Add(data);
            _db.SaveChanges();
        }
    }
}
