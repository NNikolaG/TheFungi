using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.Commands;
using theFungiApplication.DataTransfer;
using theFungiApplication.Exceptions;
using theFungiDataAccess;
using theFungiDomain.Entities;

namespace theFungiImplementation.Commands
{
    public class EFGetSingleCollectionQuery : IGetSingleCollectionQuery
    {
        private readonly theFungiDbContext _db;

        public EFGetSingleCollectionQuery(theFungiDbContext db)
        {
            _db = db;
        }

        public int Id => 4;

        public string Name => "Get Single Collection";

        public CollectionsDto Execute(int search)
        {
            var collection = _db.Collections.Include(x=>x.User)
                                            .Include(x=>x.Category)
                                            .Include(x=>x.CollectionItems)
                                            .ThenInclude(x=>x.CollectionItemInfos)
                                            .Where(x=>x.Id == search)
                                            .FirstOrDefault();

            if(collection == null)
            {
                throw new EntityNotFoundException(search, typeof(Collections));
            }

            var cDto = new CollectionsDto
            {
                Title = collection.Title,
                Username = collection.User.Username,
                Category = collection.Category.Title,
                Items = collection.CollectionItems.Select(x=> new
                {
                    Title = x.Title,
                    Image = x.Image,
                    Model = x.Model,
                    Infos = x.CollectionItemInfos.Select(z=> new
                    {
                        Title = z.Title,
                        Content = z.Content
                    })
                })
            };

            return cDto;
        }
    }
}
