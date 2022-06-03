using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication;

namespace theFungiImplementation.Loggers
{
    public class ConsoleUseCaseLogger : IUseCaseLogger
    {
        public void Log(IUseCase usecase, IApplicationActor actor, object usecaseData)
        {
            Console.WriteLine($"{DateTime.Now}: {actor.Identity} is trying to execute {usecase.Name} using data: " + $"{JsonConvert.SerializeObject(usecaseData)}");
        }
    }
}
