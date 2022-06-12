using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using theFungiApplication;
using theFungiApplication.UseCases;
using theFungiApplication.UseCases.Commands;
using theFungiApplication.UseCases.DataTransfer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace theFungiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public RegisterController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
        // POST api/<RegisterController>
        [HttpPost]
        public IActionResult Post([FromBody] RegisterDto dto, [FromServices] IRegisterUserCommand command)
        {
            _executor.ExecuteCommand(command, dto);

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
