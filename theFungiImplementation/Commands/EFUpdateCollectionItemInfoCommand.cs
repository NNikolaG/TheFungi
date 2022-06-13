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
    public class EFUpdateCollectionItemInfoCommand : IUpdateCollectionItemInfoCommand
    {
        private readonly theFungiDbContext _db;
        private readonly UpdateCollectionItemInfoValidator _validator;

        public EFUpdateCollectionItemInfoCommand(theFungiDbContext db, UpdateCollectionItemInfoValidator validator)
        {
            _validator = validator;
            _db = db;
        }
        public int Id => 32;

        public string Name => "Update Collection Item Infos";

        public void Execute(CollectionItemInfoCreateDto request)
        {
            _validator.ValidateAndThrow(request);

            var info = _db.CollectionItemInfos.Find(request.Id);

            if(info == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(CollectionItemInfos));
            }

            info.Content = request.Content;
            info.Title = request.Title;
            _db.SaveChanges();

        }
    }
}
