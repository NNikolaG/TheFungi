using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theFungiApplication.UseCases
{
    public interface IRoleUseCases
    {
        public int RoleId { get; }
        public IEnumerable<int> UseCases { get; }
    }
}
