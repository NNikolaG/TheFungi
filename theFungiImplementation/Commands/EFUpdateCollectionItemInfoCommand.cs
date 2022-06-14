using FluentValidation;
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
    public class EFUpdateCollectionItemInfoCommand : IUpdateCollectionItemInfoCommand
    {
        private readonly theFungiDbContext _db;
        private readonly UpdateCollectionItemInfoValidator _validator;
        private readonly IApplicationActor _actor;

        public EFUpdateCollectionItemInfoCommand(theFungiDbContext db, UpdateCollectionItemInfoValidator validator, IApplicationActor actor)
        {
            _validator = validator;
            _db = db;
            _actor = actor;
        }
        public int Id => 32;

        public string Name => "Update Collection Item Infos";

        public void Execute(CollectionItemInfoCreateDto request)
        {
            _validator.ValidateAndThrow(request);

            var info = _db.CollectionItemInfos.Find(request.Id);

            //Provera da li info koji se upisuje pripada item-u koji pripada jednoj od kolekcija korisnika
            var item = _db.CollectionItems.Find(request.CollectionItemId);

            var userCollectionItem = _db.Collections.Any(x => x.Id == item.CollectionId && x.UserId == _actor.Id);

            if (!userCollectionItem)
            {
                throw new KeyCombinationNotFoundException(_actor.Id, typeof(Users), item.CollectionId, typeof(Collections));
            }

            info.Content = request.Content;
            info.Title = request.Title;
            info.LastModifiedAt = DateTime.UtcNow;
            _db.SaveChanges();

        }
    }
}
