using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theFungiDomain.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeactivatedAt { get; set; }
        public int Active { get; set; }
        public int RoleId { get; set; }
        public Roles Role { get; set; }
        public virtual ICollection<Collections> Collections { get; set; } = new HashSet<Collections>();
        public virtual ICollection<Follows> FollowingCollections { get; set; } = new HashSet<Follows>();

    }
}
