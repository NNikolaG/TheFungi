using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication;
using theFungiApplication.DataTransfer;
using theFungiDataAccess;

namespace theFungiImplementation.Validators
{
    public class UpdateCollectionItemValidator : AbstractValidator<CollectionItemCreateDto>
    {
        public UpdateCollectionItemValidator(theFungiDbContext db)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Image is required");

            RuleFor(x => x.Id).NotEmpty().WithMessage("Collecton Item Id is required").Must(z => db.CollectionItems.Any(y => y.Id == z)).WithMessage("Item with given id doesn't exist");
        }
    }
}
