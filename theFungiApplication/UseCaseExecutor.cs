using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.Exceptions;

namespace theFungiApplication
{
    public class UseCaseExecutor
    {
        private readonly IApplicationActor _actor;

        public UseCaseExecutor(IApplicationActor actor)
        {
            _actor = actor;
        }
        public void ExecuteCommand<TRequest>(ICommand<TRequest> command, TRequest request)
        {
            if (!_actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(command, _actor);
            }
            command.Execute(request);
        }
    }
}
