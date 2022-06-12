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
    public class UpdateCollectionValidator : AbstractValidator<CollectionCreateDto>
    {
        public UpdateCollectionValidator(theFungiDbContext db)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Collection Titlle is required");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Collection Titlle is required");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Collection Titlle is required");

            RuleFor(x => x.UserId).Must(x => db.Users.Any(z => z.Id == x)).WithMessage("User Id doesn't exist");
            RuleFor(x => x.CategoryId).Must(x => db.Categories.Any(z => z.Id == x)).WithMessage("Category Id doesn't exist");

        }
    }
}
