using Microsoft.AspNetCore.Mvc;
using theFungiApplication;
using theFungiApplication.Commands;
using theFungiApplication.DataTransfer;
using theFungiApplication.Exceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace theFungiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstController : ControllerBase
    {
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;


        public FirstController(IApplicationActor actor, UseCaseExecutor executor)
        {
            _executor = executor;
            _actor = actor;
        }
        // GET: api/<FirstController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_actor);
        }

        // GET api/<FirstController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FirstController>
        [HttpPost]
        public void Post([FromBody] GroupDto dto, [FromServices] ICreateGroupCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }

        // PUT api/<FirstController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FirstController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteGroupCommand command)
        {
            try
            {
                _executor.ExecuteCommand(command, id);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
        }
    }
}
