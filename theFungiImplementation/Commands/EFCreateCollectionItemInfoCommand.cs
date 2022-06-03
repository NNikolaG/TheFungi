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
    public class EFCreateCollectionItemInfoCommand : ICreateCollectionItemInfoCommand
    {
        private readonly theFungiDbContext _db;
        private readonly CreateCollectionItemInfoValidator _validator;

        public EFCreateCollectionItemInfoCommand(theFungiDbContext db, CreateCollectionItemInfoValidator validator)
        {
            _validator = validator;
            _db = db;
        }
        public int Id => 7;

        public string Name => "Create item info";

        public void Execute(CollectionItemInfoCreateDto request)
        {
            _validator.ValidateAndThrow(request);

            var info = new CollectionItemInfos
            {
                Title = request.Title,
                Content = request.Content,
                CollectionItemId = request.CollectionItemId
            };

            _db.CollectionItemInfos.Add(info);
            _db.SaveChanges();
        }
    }
}
