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
    public class FakerController : ControllerBase
    {
        // GET: api/<FakerController>
        [HttpGet]
        public IActionResult Get([FromServices] theFungiDbContext db)
        {

            var roleFaker = new Faker<Roles>();
            roleFaker.RuleFor(x => x.Title, z => z.Name.JobTitle());
            var roles = roleFaker.Generate(3);

            var catFaker = new Faker<Categories>();
            catFaker.RuleFor(x => x.Title, z => z.Commerce.Department());
            var cats = catFaker.Generate(10);

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
            collectionFaker.RuleFor(x => x.BackgroundImage, z => z.Image.PicsumUrl());
            var collections = collectionFaker.Generate(20);

            var infosFaker = new Faker<CollectionItemInfos>();
            var itemsFaker = new Faker<CollectionItems>();

            itemsFaker.RuleFor(x => x.Title, z => z.Commerce.ProductName());
            itemsFaker.RuleFor(x => x.Image, z => z.Image.PicsumUrl());
            itemsFaker.RuleFor(x => x.Collection, z => z.PickRandom(collections));

            var items = itemsFaker.Generate(40);

            infosFaker.RuleFor(x => x.Title, z => z.Hacker.Noun());
            infosFaker.RuleFor(x => x.Content, z => z.Lorem.Text());
            infosFaker.RuleFor(x => x.CollectionItem, z => z.PickRandom(items));

            var infos = infosFaker.Generate(80);

            var followFaker = new Faker<Follows>();
            followFaker.RuleFor(x => x.Collection, z => z.PickRandom(collections));
            followFaker.RuleFor(x => x.User, z => z.PickRandom(users));
            var follows = followFaker.Generate(15);

            db.Follows.AddRange(follows);

            db.CollectionItemInfos.AddRange(infos);
            db.SaveChanges();

            return Ok();
        }
    }
}
