using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.UseCases;

namespace theFungiApplication.Loggers
{
    public interface IUseCaseLogger
    {
        void Log(IUseCase usecase, IApplicationActor actor, object usecaseData);
    }
}
