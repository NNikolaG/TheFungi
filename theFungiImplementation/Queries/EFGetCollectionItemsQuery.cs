using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.DataTransfer;
using theFungiApplication.UseCases.DataTransfer.Searches;
using theFungiApplication.UseCases.Queries;
using theFungiDataAccess;

namespace theFungiImplementation.Queries
{
    public class EFGetCollectionItemsQuery : IGetCollectionItemsQuery
    {
        private readonly theFungiDbContext _db;
        public EFGetCollectionItemsQuery(theFungiDbContext db)
        {
            _db = db;
        }
        public int Id => 26;

        public string Name => "Get Collection Items";

        public PageResponse<ItemsDto> Execute(SearchDto search)
        {
            var itemsQ = _db.CollectionItems.Include(x => x.CollectionItemInfos).AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) && !string.IsNullOrWhiteSpace(search.Keyword))
            {
                itemsQ = itemsQ.Where(x => x.Title.ToLower().Contains(search.Keyword.ToLower()) || x.Collection.Title.ToLower().Contains(search.Keyword.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PageResponse<ItemsDto>
            {
                Page = search.Page,
                PerPage = search.PerPage,
                TotalCount = itemsQ.Count(),
                Data = itemsQ.Skip(skipCount).Take(search.PerPage).Select(x => new ItemsDto
                {
                    Title = x.Title,
                    CollectionName = x.Collection.Title,
                    Image = x.Image,
                    Model = x.Model,
                    CollectionItemInfos = x.CollectionItemInfos.Select(x => new
                    {
                        x.Title,
                        x.Content
                    })
                }).ToList()
            };

            return response;
        }
    }
}
