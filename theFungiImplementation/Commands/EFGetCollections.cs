using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication;
using theFungiApplication.Commands;
using theFungiApplication.DataTransfer;
using theFungiDataAccess;

namespace theFungiImplementation.Commands
{
    public class EFGetCollections : IGetCategoriesQuery
    {
        private readonly theFungiDbContext _db;
        public EFGetCollections(theFungiDbContext db)
        {
            _db = db;
        }
        public int Id => 3;

        public string Name => "Get Collections";


        IEnumerable<CollectionsDto> IQuery<SearchDto, IEnumerable<CollectionsDto>>.Execute(SearchDto search)
        {
            var collectionsQ = _db.Collections.Include(x=>x.Category)
                                              .Include(x=>x.User)
                                              .Include(x=>x.CollectionItems)
                                              .AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                collectionsQ = collectionsQ.Where(x => x.Title.ToLower().Contains(search.Keyword.ToLower()) || 
                                                  x.Category.Title.ToLower().Contains(search.Keyword.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.Username))
            {
                collectionsQ = collectionsQ.Where(x => x.User.Username.ToLower().Contains(search.Username.ToLower()));
            }
            if(search.CategoryId != 0)
            {
                collectionsQ = collectionsQ.Where(x => x.CategoryId == search.CategoryId);
            }

            var collections = collectionsQ.ToList();

            var cDto = collections.Select(x => new CollectionsDto
            {
                Title = x.Title,
                Username = x.User.Username,
                Category = x.Category.Title,
                Items = x.CollectionItems.Select(x => x.Title)
            }); ;

            return cDto;
        }
    }
}
