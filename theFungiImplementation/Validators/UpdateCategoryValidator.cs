using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.UseCases.DataTransfer;
using theFungiDataAccess;

namespace theFungiImplementation.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<CategoriesDto>
    {
        public UpdateCategoryValidator(theFungiDbContext db)
        {
            RuleFor(x => x.CategoryId).Must(x => db.Categories.Any(z => z.Id == x)).WithMessage("Category with id entered doesn't exist");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Category title is required");
            RuleFor(x => x.Title).Must(x => !db.Categories.Any(z => z.Title == x)).WithMessage("Category Title must be unique");
        }
    }
}
