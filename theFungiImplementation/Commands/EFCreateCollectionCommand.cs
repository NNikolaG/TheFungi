using FluentValidation;
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
    public class EFCreateCollectionCommand : ICreateCollectionCommand
    {
        private readonly theFungiDbContext _db;
        private readonly CreateCollectionValidator _validator;
        private readonly IApplicationActor _actor;

        public EFCreateCollectionCommand(theFungiDbContext db, CreateCollectionValidator validator, IApplicationActor actor)
        {
            _validator = validator;
            _db = db;
            _actor = actor;
        }

        public int Id => 20;

        public string Name => "Create Collection Command";

        public void Execute(CollectionCreateDto request)
        {
            _validator.ValidateAndThrow(request);

            var collection = new Collections
            {
                Title = request.Title,
                CategoryId = request.CategoryId,
                UserId = _actor.Id,
                BackgroundImage = request.BackgroundImage,
                CreatedAt = DateTime.UtcNow
            };

            _db.Collections.Add(collection);
            _db.SaveChanges();

        }
    }
}
