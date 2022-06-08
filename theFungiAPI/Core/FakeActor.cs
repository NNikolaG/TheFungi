using System.Collections.Generic;
using System.Linq;
using theFungiApplication;

namespace theFungiAPI.Core
{
    public class FakeActor : IApplicationActor
    {
        public int Id => 1;
        public string Identity => "Prvi actor";
        public IEnumerable<int> AllowedUseCases => Enumerable.Range(1, 30).ToList();

    }
}
