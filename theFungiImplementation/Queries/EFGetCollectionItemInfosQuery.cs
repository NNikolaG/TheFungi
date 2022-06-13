using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.DataTransfer;
using theFungiApplication.UseCases.DataTransfer;
using theFungiApplication.UseCases.DataTransfer.Searches;
using theFungiApplication.UseCases.Queries;
using theFungiDataAccess;

namespace theFungiImplementation.Queries
{
    public class EFGetCollectionItemInfosQuery : IGetCollectionItemInfosQuery
    {
        private readonly theFungiDbContext _db;
        public EFGetCollectionItemInfosQuery(theFungiDbContext db)
        {
            _db = db;
        }

        public int Id => 31;

        public string Name => "Get Collection Item Infos";

        public PageResponse<CollectionItemInfoDto> Execute(SearchDto search)
        {

            var infoQ = _db.CollectionItemInfos.Include(x => x.CollectionItem).AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) && !string.IsNullOrEmpty(search.Keyword))
            {
                infoQ = infoQ.Where(x => x.Title.ToLower().Contains(search.Keyword.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PageResponse<CollectionItemInfoDto>
            {
                Page = search.Page,
                PerPage = search.PerPage,
                TotalCount = infoQ.Count(),
                Data = infoQ.Skip(skipCount).Take(search.PerPage).Select(x => new CollectionItemInfoDto
                {
                    Title = x.Title,
                    Content = x.Content,
                    CollectionItemTitle = x.CollectionItem.Title
                }).ToList()
            };

            return response;
        }
    }
}
