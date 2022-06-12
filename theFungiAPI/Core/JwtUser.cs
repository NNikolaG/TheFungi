using System.Collections.Generic;
using theFungiApplication;

namespace theFungiAPI.Core
{
    public class JwtUser : IApplicationActor
    {
        public string Identity { get; set; }

        public int Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<int> AllowedUseCases { get; set; } = new List<int>();
    }

    public class AnonimousUser : IApplicationActor
    {
        public string Identity => "Anonymous";

        public int Id => 0;

        public string Email => "anonimous@asp-api.com";

        public IEnumerable<int> AllowedUseCases => new List<int> { 9 };
    }
}
