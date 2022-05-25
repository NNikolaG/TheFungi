using System.Collections.Generic;
using theFungiApplication;

namespace theFungiAPI.Core
{
    public class FakeActor : IApplicationActor
    {
        public int Id => 1;
        public string Identity => "Prvi actor";
        public IEnumerable<int> AllowedUseCases => new List<int> { 1,2,3 };

    }
}
