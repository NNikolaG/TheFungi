using FluentValidation;
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
using theFungiImplementation.Validators;

namespace theFungiImplementation.Commands
{
    public class EFUpdateCollectionsCommand : IUpdateCollectionsCommand
    {
        private readonly theFungiDbContext _db;
        private readonly UpdateCollectionValidator _validator;

        public EFUpdateCollectionsCommand(theFungiDbContext db, UpdateCollectionValidator validator)
        {
            _db = db;
            _validator = validator;
        }

        public int Id => 16;

        public string Name => "Update Collections Command";

        public void Execute(CollectionCreateDto request)
        {
            _validator.ValidateAndThrow(request);

            var collection = _db.Collections.Find(request.Id);

            if(collection == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Collections));
            }

            collection.Title = request.Title;
            collection.UserId = request.UserId;
            collection.CategoryId = request.CategoryId;

            if(request.CategoryId != null)
            {
                collection.CategoryId = request.CategoryId;
            }

            if(request.BackgroundImage != null)
            {
                collection.BackgroundImage = request.BackgroundImage;
            }



        }
    }
}
