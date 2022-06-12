using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using theFungiApplication;
using theFungiApplication.Commands;
using theFungiApplication.DataTransfer;
using theFungiApplication.Queries;
using theFungiApplication.UseCases;
using theFungiApplication.UseCases.Commands;
using theFungiApplication.UseCases.DataTransfer.Searches;
using theFungiDataAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace theFungiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public CollectionsController(UseCaseExecutor executor)
        {
            _executor = executor;
        }


        // GET: api/<CollectionsController>
        [HttpGet]
        public IActionResult Get([FromQuery] CollectionSearch search, [FromServices] IGetCollectionsQuery get)
        {
            var data = _executor.ExecuteQuery(get, search);
            return Ok(data);
        }

        // GET api/<CollectionsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetSingleCollectionQuery get)
        {
            var data = _executor.ExecuteQuery(get, id);
            return Ok(data);
        }

        [Authorize]
        // POST api/<CollectionsController>
        [HttpPost]
        public void Post([FromBody] CollectionCreateDto dto, [FromServices] ICreateCollectionCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }

        [Authorize]
        // PUT api/<CollectionsController>/5
        [HttpPut]
        public IActionResult Put([FromBody] CollectionCreateDto dto, [FromServices] IUpdateCollectionsCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        [Authorize]
        // DELETE api/<CollectionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
