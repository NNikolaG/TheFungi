using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.UseCases.Commands;
using theFungiApplication.UseCases.DataTransfer;
using theFungiDataAccess;
using theFungiImplementation.Validators;

namespace theFungiImplementation.Commands
{
    public class EFChangeUserRoleCommand : IChangeUserRoleCommand
    {
        private readonly theFungiDbContext _db;
        private readonly ChangeUserRoleValidator _validator;

        public EFChangeUserRoleCommand(theFungiDbContext db, ChangeUserRoleValidator validator)
        {
            _validator = validator;
            _db = db;
        }

        public int Id => 10;

        public string Name => "Change User Role";

        public void Execute(RoleChangeDto request)
        {
            _validator.ValidateAndThrow(request);

            var admin = new List<int> { 4, 5, 6, 7, 8, 9, 10 };
            var user = new List<int> { 1, 2, 3, 4 };
            


        }
    }
}
