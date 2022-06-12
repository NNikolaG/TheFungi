using System.Collections.Generic;
using theFungiApplication;

namespace theFungiAPI.Core
{
    public class JwtActor : IApplicationActor
    {
        public int Id { get; set; }

        public string Identity { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; }

        public string Email { get; set; }
    }
}
