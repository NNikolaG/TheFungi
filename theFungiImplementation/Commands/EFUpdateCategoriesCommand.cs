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
    public class EFUpdateCategoriesCommand : IUpdateCategoriesCommand
    {
        private readonly theFungiDbContext _db;
        private readonly UpdateCategoryValidator _validator;

        public EFUpdateCategoriesCommand(theFungiDbContext db, UpdateCategoryValidator validator)
        {
            _validator = validator;
            _db = db;
        }
        public int Id => 14;

        public string Name => "Update Category Command";

        public void Execute(CategoriesDto request)
        {
            _validator.ValidateAndThrow(request);

            var category = _db.Categories.Where(x => x.Id == request.CategoryId).FirstOrDefault();

            category.Title = request.Title;
            category.LastModifiedAt = DateTime.UtcNow;

            _db.SaveChanges();

        }
    }
}
