using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using theFungiApplication.UseCases;
using theFungiApplication.UseCases.Commands;
using theFungiApplication.UseCases.DataTransfer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace theFungiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesChangeController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public RolesChangeController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        [Authorize]
        // PUT api/<RolesChangeController>
        [HttpPut]
        public IActionResult Put([FromBody] RoleChangeDto dto, [FromServices] IChangeUserRoleCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }
    }
}
