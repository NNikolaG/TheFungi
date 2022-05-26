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
    public class CreateCollectionValidator : AbstractValidator<CollectionCreateDto>
    {

        public CreateCollectionValidator(theFungiDbContext db)
        {
                RuleFor(x => x.Title).NotEmpty().WithMessage("Collection Title is required");
            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage("Collection Category is required, please select one that and try again")
                .DependentRules(() =>
                {
                    RuleFor(x => x.CategoryId).Must(x =>
                    {
                        return db.Categories.Any(z => z.Id == x);
                    })
                    .WithMessage("Category must exist");
                });

                RuleFor(x => x.UserId)
                    .NotEmpty()
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UserId).Must(x =>
                        {
                            return db.Users.Any(z => z.Id == x);
                        })
                        .WithMessage("User must exist");
                    });
        }
    }
}
