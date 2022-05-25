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
    public class CreateGroupValidator : AbstractValidator<GroupDto>
    {

        public CreateGroupValidator(theFungiDbContext db)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Must(name => !db.Group.Any(z => z.Name == name))
                .WithMessage("Group Name must be unique");
  
        }
    }
}
