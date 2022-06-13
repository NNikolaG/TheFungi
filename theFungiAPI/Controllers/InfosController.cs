using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using theFungiApplication;
using theFungiApplication.Commands;
using theFungiApplication.DataTransfer;
using theFungiApplication.UseCases;
using theFungiApplication.UseCases.Commands;
using theFungiApplication.UseCases.DataTransfer.Searches;
using theFungiApplication.UseCases.Queries;
using theFungiDataAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace theFungiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfosController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public InfosController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
        // GET: api/<InfosController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchDto dto, [FromServices] IGetCollectionItemInfosQuery query)
        {
            var data = _executor.ExecuteQuery(query, dto);
            return Ok(data);
        }

        [Authorize]
        // POST api/<InfosController>
        [HttpPost]
        public IActionResult Post([FromBody] CollectionItemInfoCreateDto dto, [FromServices] ICreateCollectionItemInfoCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [Authorize]
        // PUT api/<InfosController>/5
        [HttpPut]
        public IActionResult Put([FromBody] CollectionItemInfoCreateDto dto, [FromServices] IUpdateCollectionItemInfoCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        [Authorize]
        // DELETE api/<InfosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCollectionItemInfoCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
