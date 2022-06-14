using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
    public class UpdateCollectionValidator : AbstractValidator<CollectionCreateDto>
    {
        public UpdateCollectionValidator(theFungiDbContext db, IApplicationActor actor)
        {
            RuleFor(x => x.CategoryId).Must(x => db.Categories.Any(z => z.Id == x)).WithMessage("Category Id doesn't exist");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Collection Id is required").DependentRules(() =>
            {
                RuleFor(x => x.Id).Must(x =>
                {
                    return db.Collections.Any(z => z.Id == x && z.UserId == actor.Id);
                }).WithMessage("You don't have Collection with passed Id");
            });
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
        }
    }
}
