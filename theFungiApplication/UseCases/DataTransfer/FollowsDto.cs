using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theFungiApplication.UseCases.DataTransfer
{
    public class FollowsDto
    {
        public int CollectionId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string ProfileImage { get; set; }
    }
}
