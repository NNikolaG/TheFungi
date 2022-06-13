using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.UseCases.DataTransfer;
using theFungiApplication.UseCases.Queries;
using theFungiDataAccess;

namespace theFungiImplementation.Queries
{
    public class EFGetFollowersQuery : IGetFollowersQuery
    {
        private readonly theFungiDbContext _db;
        public EFGetFollowersQuery(theFungiDbContext db)
        {
            _db = db;
        }
        public int Id => 21;

        public string Name => "Get Followers";

        public IEnumerable<FollowsDto> Execute(FollowsDto search)
        {
            var followers = _db.Follows.Include(x => x.User).Where(x => x.CollectionId == search.CollectionId).ToList();

            var data = followers.Select(x => new FollowsDto
            {
                Username = x.User.Username,
                ProfileImage = x.User.ProfileImage,
                CollectionId = x.CollectionId,
                UserId = x.UserId
            });

            return data;
        }
    }
}
