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
    public class CollectionsController : ControllerBase
    {
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;
        private readonly theFungiDbContext _db;

        public CollectionsController(IApplicationActor actor, UseCaseExecutor executor, theFungiDbContext db)
        {
            _db = db;
            _actor = actor;
            _executor = executor;
        }


        // GET: api/<CollectionsController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchDto search, [FromServices] IGetCategoriesQuery get)
        {
            var data = get.Execute(search);
            return Ok(data);
        }

        // GET api/<CollectionsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetSingleCollectionQuery get)
        {
            var data = get.Execute(id);
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
