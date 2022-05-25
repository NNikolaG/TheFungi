using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theFungiApplication.Exceptions
{
    public class UnauthorizedUseCaseException : Exception
    {
        public UnauthorizedUseCaseException(IUseCase usecase, IApplicationActor actor)
            :base($"Actor: {actor.Id} - {actor.Identity} tried to execute command : {usecase.Name}")
        {

        }
    }
}
