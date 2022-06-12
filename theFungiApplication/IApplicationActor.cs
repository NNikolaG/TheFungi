using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theFungiApplication
{
    public interface IApplicationActor
    {
        public int Id { get; }
        public string Identity { get; }
        public IEnumerable<int> AllowedUseCases { get; } 
        public string Email { get; }
    }
}
