using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public EFCreateFollowCommand(theFungiDbContext db, CreateFollowValidator validator)
        {
            _validator = validator;
            _db = db;
        }
        public int Id => 8;

        public string Name => "Create Follow";

        public void Execute(CreateFollowDto request)
        {
            _validator.ValidateAndThrow(request);
            var followedCollections = _db.Collections
                .Include(x => x.User)
                .ThenInclude(x => x.FollowingCollections)
                .Where(x => x.UserId == request.UserId)
                .ToList();

            if (followedCollections.Any(x=>x.Id == request.CollectionId))
            {
                throw new Exception("Follow already exists");
            }

            var fDto = new Follow
            {
                UserId = request.UserId,
                CollectionId = request.CollectionId
            };

            _db.Follows.Add(fDto);
            _db.SaveChanges();
        }
    }
}
