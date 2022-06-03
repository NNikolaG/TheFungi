using Microsoft.AspNetCore.Mvc;
using theFungiApplication;
using theFungiApplication.Commands;
using theFungiApplication.DataTransfer;
using theFungiApplication.Queries;
using theFungiDataAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace theFungiAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;

        public ItemsController(IApplicationActor actor, UseCaseExecutor executor)
        {
            _actor = actor;
            _executor = executor;
        }

        // GET: api/<ItemsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetSingleCollectionItemQuery command)
        {
            var data = _executor.ExecuteQuery(command, id);
            return Ok(data);
        }

        // POST api/<ItemsController>
        [HttpPost]
        public void Post([FromBody] CollectionItemCreateDto dto, [FromServices] ICreateCollectionItemCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
