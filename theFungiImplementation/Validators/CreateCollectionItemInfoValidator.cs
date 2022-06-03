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
    public class CreateCollectionItemInfoValidator : AbstractValidator<CollectionItemInfoCreateDto>
    {
        public CreateCollectionItemInfoValidator(theFungiDbContext db)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Info Title is required");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Info Content is required");
            RuleFor(x => x.CollectionItemId).NotEmpty().WithMessage("Collection Item id is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.CollectionItemId).Must(x =>
                    {
                        return db.CollectionItems.Any(z => z.Id == x);
                    }).WithMessage("Collection item don't exists");
                });
        }
    }
}
