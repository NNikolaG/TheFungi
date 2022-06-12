using Microsoft.AspNetCore.Mvc;
using theFungiApplication;
using theFungiApplication.Commands;
using theFungiApplication.DataTransfer;
using theFungiApplication.UseCases;
using theFungiDataAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace theFungiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;

        public FollowController(IApplicationActor actor, UseCaseExecutor executor)
        {
            _actor = actor;
            _executor = executor;
        }
        // GET: api/<FollowController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET api/<FollowController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FollowController>
        [HttpPost]
        public void Post([FromBody] CreateFollowDto dto, [FromServices] ICreateFollowCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }

        // PUT api/<FollowController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FollowController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
