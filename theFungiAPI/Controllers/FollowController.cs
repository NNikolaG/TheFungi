using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using theFungiApplication;
using theFungiApplication.Commands;
using theFungiApplication.DataTransfer;
using theFungiApplication.UseCases;
using theFungiApplication.UseCases.Commands;
using theFungiApplication.UseCases.DataTransfer;
using theFungiApplication.UseCases.Queries;
using theFungiDataAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace theFungiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public FollowController(IApplicationActor actor, UseCaseExecutor executor)
        {
            _executor = executor;
        }
        [Authorize]
        // GET: api/<FollowController>
        [HttpGet]
        public IActionResult Get([FromQuery] FollowsDto dto, [FromServices] IGetFollowersQuery query)
        {
            var data = _executor.ExecuteQuery(query, dto);
            return Ok(data);
        }

        [Authorize]
        // POST api/<FollowController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateFollowDto dto, [FromServices] ICreateFollowCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [Authorize]
        // DELETE api/<FollowController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteFollowCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
