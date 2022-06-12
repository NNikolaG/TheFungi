using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication;
using theFungiApplication.DataTransfer;
using theFungiApplication.Queries;
using theFungiApplication.UseCases.DataTransfer.Searches;
using theFungiDataAccess;

namespace theFungiImplementation.Queries
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


        public PageResponse<CollectionsDto> Execute(CollectionSearch search)
        {
            var collectionsQ = _db.Collections.Include(x => x.Category)
                                              .Include(x => x.User)
                                              .Include(x => x.CollectionItems)
                                              .ThenInclude(x => x.CollectionItemInfos)
                                              .AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                collectionsQ = collectionsQ.Where(x => x.Title.ToLower().Contains(search.Keyword.ToLower()) ||
                                                  x.Category.Title.ToLower().Contains(search.Keyword.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.Username) || !string.IsNullOrWhiteSpace(search.Username))
            {
                collectionsQ = collectionsQ.Where(x => x.User.Username.ToLower().Contains(search.Username.ToLower()));
            }
            if (search.CategoryId != 0)
            {
                collectionsQ = collectionsQ.Where(x => x.CategoryId == search.CategoryId);
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PageResponse<CollectionsDto>
            {
                Page = search.Page,
                PerPage = search.PerPage,
                TotalCount = collectionsQ.Count(),
                Data = collectionsQ.Skip(skipCount).Take(search.PerPage).Select(x => new CollectionsDto
                {
                    Title = x.Title,
                    Username = x.User.Username,
                    Category = x.Category.Title,
                    Items = x.CollectionItems.Select(x => new
                    {
                        x.Title,
                        x.Image,
                        x.Model,
                        Infos = x.CollectionItemInfos.Select(z => new
                        {
                            z.Title,
                            z.Content
                        })
                    })
                }).ToList()
            };

            return response;
        }
    }
}
