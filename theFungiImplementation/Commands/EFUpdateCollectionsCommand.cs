using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
using theFungiImplementation.Validators;

namespace theFungiImplementation.Commands
{
    public class EFUpdateCollectionsCommand : IUpdateCollectionsCommand
    {
        private readonly theFungiDbContext _db;
        private readonly UpdateCollectionValidator _validator;
        private readonly IApplicationActor _actor;

        public EFUpdateCollectionsCommand(theFungiDbContext db, UpdateCollectionValidator validator, IApplicationActor actor)
        {
            _db = db;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 16;

        public string Name => "Update Collections Command";

        public void Execute(CollectionCreateDto request)
        {
            _validator.ValidateAndThrow(request);

            var collection = _db.Collections.Where(x => x.Id == request.Id).FirstOrDefault();

            collection.LastModifiedAt = DateTime.UtcNow;

            collection.Title = request.Title;

            collection.CategoryId = request.CategoryId;

            if (request.BackgroundImage != null)
            {
                collection.BackgroundImage = request.BackgroundImage;
            }

            _db.SaveChanges();

        }
    }
}
