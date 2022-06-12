using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.Email;
using theFungiApplication.UseCases.Commands;
using theFungiApplication.UseCases.DataTransfer;
using theFungiDataAccess;
using theFungiDomain.Entities;
using theFungiImplementation.Validators;

namespace theFungiImplementation.Commands
{
    public class EFRegisterUserCommand : IRegisterUserCommand
    {
        private readonly RegisterUserValidator _validator;
        private readonly IEmailSender _sender;
        private readonly theFungiDbContext _db;

        public EFRegisterUserCommand(RegisterUserValidator validator, IEmailSender sender, theFungiDbContext db)
        {
            _validator = validator;
            _sender = sender;
            _db = db;
        }

        public int Id => 9;

        public string Name => "User Registration";

        public void Execute(RegisterDto request)
        {
            _validator.ValidateAndThrow(request);

            var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new Users
            {
                Username = request.Username,
                Email = request.Email,
                Password = hash,
                FirstName = request.FirstName,
                LastName = request.LastName,
                ProfileImage = "default.img",
                CreatedAt = DateTime.UtcNow,
                RoleId = 5
            };

            _db.Users.Add(user);
            _db.SaveChanges();

            //slanje email-a za verifikaciju

            _sender.Send(new MessageDto
            {
                To = request.Email,
                Title = "Successfull registration!",
                Body = "Dear " + request.Username + "\n Please activate your account...."
            });
        }
    }
}
