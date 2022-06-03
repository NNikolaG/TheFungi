using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.Commands;
using theFungiApplication.DataTransfer;
using theFungiApplication.Exceptions;
using theFungiApplication.Queries;
using theFungiDataAccess;
using theFungiDomain.Entities;

namespace theFungiImplementation.Queries
{
    public class EFGetSingleCollectionItemQuery : IGetSingleCollectionItemQuery
    {
        private readonly theFungiDbContext _db;
        public EFGetSingleCollectionItemQuery(theFungiDbContext db)
        {
            _db = db;
        }
        public int Id => 8;

        public string Name => "Get Single Item From Collection";

        public ItemsDto Execute(int search)
        {
            var item = _db.CollectionItems
                .Include(x => x.CollectionItemInfos)
                .Include(x => x.Collection)
                .Where(x => x.Id == search).FirstOrDefault();
            if (item == null)
            {
                throw new EntityNotFoundException(search, typeof(CollectionItems));
            }
            var iDto = new ItemsDto
            {
                Title = item.Title,
                Image = item.Image,
                Model = item.Model,
                CollectionName = item.Collection.Title,
                CollectionItemInfos = item.CollectionItemInfos.Select(x => new
                {
                    InfoTitle = x.Title,
                    InfoContent = x.Content
                })
            };
            return iDto;
        }
    }
}
