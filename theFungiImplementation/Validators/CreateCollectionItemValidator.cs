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
    public class CreateCollectionItemValidator : AbstractValidator<CollectionItemCreateDto>
    {
        public CreateCollectionItemValidator(theFungiDbContext db, IApplicationActor actor)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Image is required");
            RuleFor(x => x.CollectionId)
                .NotEmpty().WithMessage("CollectionId is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.CollectionId).Must(x =>
                    {
                        return db.Collections.Any(z => z.Id == x);
                    })
                    .WithMessage("Collection must exist");
                    RuleFor(x => x.CollectionId).Must(x =>
                    {
                        return db.Collections.Any(z => z.UserId == actor.Id && z.Id == x);
                    }).WithMessage("User doesn't have collection with given id");
                });
        }
    }
}
