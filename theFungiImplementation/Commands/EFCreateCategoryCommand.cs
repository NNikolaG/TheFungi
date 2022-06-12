using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.UseCases.Commands;
using theFungiApplication.UseCases.DataTransfer;
using theFungiDataAccess;
using theFungiDomain.Entities;
using theFungiImplementation.Validators;

namespace theFungiImplementation.Commands
{
    public class EFCreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly theFungiDbContext _db;
        private readonly CreateCategoryValidator _validator;

        public EFCreateCategoryCommand(theFungiDbContext db, CreateCategoryValidator validator)
        {
            _validator = validator;
            _db = db;
        }
        public int Id => 12;

        public string Name => "Create Category";

        public void Execute(CategoriesDto request)
        {
            _validator.ValidateAndThrow(request);

            var category = new Categories
            {
                Title = request.Title,
                CreatedAt = DateTime.UtcNow
            };

            _db.Categories.Add(category);
            _db.SaveChanges();
        }
    }
}
