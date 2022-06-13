using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using theFungiApplication.UseCases;
using theFungiApplication.UseCases.DataTransfer.Searches;
using theFungiApplication.UseCases.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace theFungiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public LogController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
        [Authorize]
        // GET: api/<LogController>
        [HttpGet]
        public IActionResult Get([FromQuery] LogSearchDto dto, [FromServices] IGetLogsQuery query)
        {
            var data = _executor.ExecuteQuery(query, dto);
            return Ok(data);
        }
    }
}
