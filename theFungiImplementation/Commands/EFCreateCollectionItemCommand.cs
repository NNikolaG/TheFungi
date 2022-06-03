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
    public class EFCreateCollectionItemCommand : ICreateCollectionItemCommand
    {
        private readonly theFungiDbContext _db;
        private readonly CreateCollectionItemValidator _validator;

        public EFCreateCollectionItemCommand(theFungiDbContext db, CreateCollectionItemValidator validator)
        {
            _validator = validator;
            _db = db;
        }
        public int Id => 7;

        public string Name => "Add Item to Collection";

        public void Execute(CollectionItemCreateDto request)
        {
            _validator.ValidateAndThrow(request);

            var item = new CollectionItems
            {
                Title = request.Title,
                Image = request.Image,
                Model = request.Model,
                CollectionId = request.CollectionId
            };

            _db.CollectionItems.Add(item);
            _db.SaveChanges();
        }
    }
}
