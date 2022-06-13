using FluentValidation;
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
    public class EFCreateCollectionCommand : ICreateCollectionCommand
    {
        private readonly theFungiDbContext _db;
        private readonly CreateCollectionValidator _validator;

        public EFCreateCollectionCommand(theFungiDbContext db, CreateCollectionValidator validator)
        {
            _validator = validator;
            _db = db;
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
                UserId = request.UserId,
                BackgroundImage = request.BackgroundImage,
                CreatedAt = DateTime.UtcNow
            };

            _db.Collections.Add(collection);
            _db.SaveChanges();

        }
    }
}
