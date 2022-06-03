using Microsoft.AspNetCore.Mvc;
using theFungiApplication;
using theFungiApplication.Commands;
using theFungiApplication.DataTransfer;
using theFungiDataAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace theFungiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfosController : ControllerBase
    {
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;

        public InfosController(IApplicationActor actor, UseCaseExecutor executor)
        {
            _actor = actor;
            _executor = executor;
        }
        // GET: api/<InfosController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET api/<InfosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InfosController>
        [HttpPost]
        public void Post([FromBody] CollectionItemInfoCreateDto dto, [FromServices] ICreateCollectionItemInfoCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }

        // PUT api/<InfosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InfosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
