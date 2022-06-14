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
    public class CreateFollowValidator : AbstractValidator<CreateFollowDto>
    {
        public CreateFollowValidator(theFungiDbContext db, IApplicationActor actor)
        {

            RuleFor(x => x.CollectionId).NotEmpty().WithMessage("Collection ID is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.CollectionId).Must(x =>
                    {
                        return db.Collections.Any(z => z.Id == x);
                    }).WithMessage("Collection must exist");
                    RuleFor(x => x.CollectionId).Must(x =>
                    {
                        return !db.Follows.Any(z => z.CollectionId == x && z.UserId == actor.Id);
                    }).WithMessage("Follow already exists");
                });
            
        }
    }
}
