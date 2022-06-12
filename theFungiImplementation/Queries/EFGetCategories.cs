using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.UseCases;
using theFungiApplication.UseCases.DataTransfer;
using theFungiApplication.UseCases.DataTransfer.Searches;
using theFungiApplication.UseCases.Queries;
using theFungiDataAccess;

namespace theFungiImplementation.Queries
{
    public class EFGetCategories : IGetCategoriesQuery
    {
        private readonly theFungiDbContext _db;
        public EFGetCategories(theFungiDbContext db)
        {
            _db = db;
        }

        public int Id => 11;

        public string Name => "Get Categories";


        IEnumerable<CategoriesDto> IQuery<SearchDto, IEnumerable<CategoriesDto>>.Execute(SearchDto search)
        {
            var categoriesQ = _db.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                categoriesQ = categoriesQ.Where(x => x.Title.ToLower().Contains(search.Keyword.ToLower()));
            }

            var categories = categoriesQ.ToList();

            var data = categories.Select(x => new CategoriesDto
            {
                CategoryId = x.Id,
                Title = x.Title
            });

            return data;
        }
    }
}
