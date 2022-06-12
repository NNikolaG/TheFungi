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
    public class ChangeUserRoleValidator : AbstractValidator<RoleChangeDto>
    {
        public ChangeUserRoleValidator(theFungiDbContext _db)
        {
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("RoleId is required")
                                  .Must(x => _db.Roles.Any(z => z.Id == x)).WithMessage("Role entered doesn't exist");
        }
    }
}
