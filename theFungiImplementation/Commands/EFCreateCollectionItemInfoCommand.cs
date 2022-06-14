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
using theFungiApplication.Exceptions;
using theFungiDataAccess;
using theFungiDomain.Entities;
using theFungiImplementation.Validators;

namespace theFungiImplementation.Commands
{
    public class EFCreateCollectionItemInfoCommand : ICreateCollectionItemInfoCommand
    {
        private readonly theFungiDbContext _db;
        private readonly CreateCollectionItemInfoValidator _validator;
        private readonly IApplicationActor _actor;

        public EFCreateCollectionItemInfoCommand(theFungiDbContext db, CreateCollectionItemInfoValidator validator, IApplicationActor actor)
        {
            _validator = validator;
            _db = db;
            _actor = actor;
        }
        public int Id => 30;

        public string Name => "Create Item info";

        public void Execute(CollectionItemInfoCreateDto request)
        {
            _validator.ValidateAndThrow(request);

            //Provera da li info koji se upisuje pripada item-u koji pripada jednoj od kolekcija korisnika
            var item = _db.CollectionItems.Find(request.CollectionItemId);

            var userCollectionItem = _db.Collections.Any(x => x.Id == item.CollectionId && x.UserId == _actor.Id);

            if (!userCollectionItem)
            {
                throw new KeyCombinationNotFoundException(_actor.Id, typeof(Users), item.CollectionId, typeof(Collections));
            }

            var info = new CollectionItemInfos
            {
                Title = request.Title,
                Content = request.Content,
                CollectionItemId = request.CollectionItemId,
                CreatedAt = DateTime.UtcNow
            };

            _db.CollectionItemInfos.Add(info);
            _db.SaveChanges();
        }
    }
}
