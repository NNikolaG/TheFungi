using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.Exceptions;
using theFungiApplication.UseCases.DataTransfer;
using theFungiApplication.UseCases.Queries;
using theFungiDataAccess;
using theFungiDomain.Entities;

namespace theFungiImplementation.Queries
{
    public class EFGetSingleCategoryQuery : IGetSingleCategoryQuery
    {
        private readonly theFungiDbContext _db;
        public EFGetSingleCategoryQuery(theFungiDbContext db)
        {
            _db = db;
        }

        public int Id => 13;

        public string Name => "Get Single Category";

        public CategoriesDto Execute(int search)
        {
            var category = _db.Categories.Where(x => x.Id == search).FirstOrDefault();

            if (category == null)
            {
                throw new EntityNotFoundException(search, typeof(Categories));
            }

            var data = new CategoriesDto
            {
                Title = category.Title,
                CategoryId = category.Id
            };

            return data; 
        }
    }
}
