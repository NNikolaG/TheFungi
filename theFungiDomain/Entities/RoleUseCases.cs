using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theFungiDomain.Entities
{
    public class RoleUseCases
    {
        public int RoleId { get; set; }
        public virtual Roles Role { get; set; }
        public int UseCaseId { get; set; }
    }
}
