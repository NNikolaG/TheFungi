using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.DataTransfer;
using theFungiDataAccess;

namespace theFungiImplementation.Validators
{
    public class UpdateCollectionItemInfoValidator : AbstractValidator<CollectionItemInfoCreateDto>
    {
        public UpdateCollectionItemInfoValidator(theFungiDbContext db)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Info Title is required");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Info Content is required");

            RuleFor(x => x.CollectionItemId).NotEmpty().WithMessage("Collection Item id is required").Must(x => db.CollectionItems.Any(z => z.Id == x)).WithMessage("Given Collection Item id doesn't exist");

            RuleFor(x => x.Id).Must(x => db.CollectionItemInfos.Any(z => z.Id == x)).WithMessage("Given Collection Item Info id doesn't exit");
        }
    }

}
