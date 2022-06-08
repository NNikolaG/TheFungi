using Bogus;
using Microsoft.AspNetCore.Mvc;
using theFungiApplication;
using theFungiApplication.Commands;
using theFungiApplication.DataTransfer;
using theFungiApplication.Exceptions;
using theFungiDataAccess;
using theFungiDomain.Entities;

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
        public IActionResult Get([FromServices] theFungiDbContext db)
        {

            var roleFaker = new Faker<Roles>();
            roleFaker.RuleFor(x => x.Title, z => z.Name.JobTitle());
            var roles = roleFaker.Generate(3);

            var catFaker = new Faker<Categories>();
            catFaker.RuleFor(x => x.Title, z => z.Commerce.Department());
            var cats = catFaker.Generate(4);

            var userFaker = new Faker<Users>();
            userFaker.RuleFor(x => x.Email, z => z.Internet.Email());
            userFaker.RuleFor(x => x.Username, z => z.Internet.UserName());
            userFaker.RuleFor(x => x.FirstName, z => z.Name.FirstName());
            userFaker.RuleFor(x => x.LastName, z => z.Name.LastName());
            userFaker.RuleFor(x => x.Password, z => z.Internet.Password());
            userFaker.RuleFor(x => x.Role, z => z.PickRandom(roles));
            userFaker.RuleFor(x => x.ProfileImage, z => z.Image.PicsumUrl());
            userFaker.RuleFor(x => x.CreatedAt, z => z.Date.Past());

            var users = userFaker.Generate(10);


            var collectionFaker = new Faker<Collections>();
            collectionFaker.RuleFor(x => x.Title, z => z.Commerce.ProductName());
            collectionFaker.RuleFor(x => x.User, z => z.PickRandom(users));
            collectionFaker.RuleFor(x => x.Category, z => z.PickRandom(cats));
            //collectionFaker.RuleFor(x => x.CollectionFollowers, z => followFaker.Generate(2));

            var collections = collectionFaker.Generate(4);

            var infosFaker = new Faker<CollectionItemInfos>();
            var itemsFaker = new Faker<CollectionItems>();

            itemsFaker.RuleFor(x => x.Title, z => z.Commerce.ProductName());
            itemsFaker.RuleFor(x => x.Image, z => z.Image.PicsumUrl());
            itemsFaker.RuleFor(x => x.Collection, z => z.PickRandom(collections));

            var items = itemsFaker.Generate(20);

            infosFaker.RuleFor(x => x.Title, z => z.Hacker.Noun());
            infosFaker.RuleFor(x => x.Content, z => z.Lorem.Text());
            infosFaker.RuleFor(x => x.CollectionItem, z => z.PickRandom(items));

            var infos = infosFaker.Generate(30);

            db.CollectionItemInfos.AddRange(infos);
            db.SaveChanges();

            return Ok();
        }

        // GET api/<FirstController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FirstController>
        [HttpPost]
        public void Post()
        {
        }

        // PUT api/<FirstController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FirstController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
