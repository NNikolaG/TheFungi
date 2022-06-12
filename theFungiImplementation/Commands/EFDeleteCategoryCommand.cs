using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.Application.Exceptions;
using theFungiApplication.Exceptions;
using theFungiApplication.UseCases.Commands;
using theFungiDataAccess;
using theFungiDomain.Entities;

namespace theFungiImplementation.Commands
{
    public class EFDeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly theFungiDbContext _db;

        public EFDeleteCategoryCommand(theFungiDbContext db)
        {
            _db = db;
        }
        public int Id => 15;

        public string Name => "Delete Category Command";

        public void Execute(int request)
        {
            var category = _db.Categories.Where(x => x.Id == request).FirstOrDefault();

            if(category == null)
            {
                throw new EntityNotFoundException(request, typeof(Categories));
            }

            var contains = _db.Collections.Any(x=>x.CategoryId == category.Id);

            if(contains == true)
            {
                throw new UseCaseConflictException("Unable to delete category type because it is linked to collections.");
            }

            _db.Categories.Remove(category);
            _db.SaveChanges();
        }
    }
}
