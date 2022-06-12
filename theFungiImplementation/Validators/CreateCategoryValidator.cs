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
    public class CreateCategoryValidator : AbstractValidator<CategoriesDto>
    {
        public CreateCategoryValidator(theFungiDbContext db)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Category title is required");
            RuleFor(x => x.Title).Must(x => !db.Categories.Any(z => z.Title == x)).WithMessage("Category Title must be unique");
        }
    }
}
