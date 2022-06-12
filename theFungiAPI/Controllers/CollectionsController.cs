using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using theFungiApplication;
using theFungiApplication.Commands;
using theFungiApplication.DataTransfer;
using theFungiApplication.Queries;
using theFungiApplication.UseCases;
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
        [Authorize]

        public IActionResult Get([FromQuery] CollectionSearch search, [FromServices] IGetCategoriesQuery get)
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

        // POST api/<CollectionsController>
        [HttpPost]
        public void Post([FromBody] CollectionCreateDto dto, [FromServices] ICreateCollectionCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }

        // PUT api/<CollectionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CollectionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
