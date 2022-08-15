using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.WebAPI.Class02.Api.Models;

namespace SEDC.WebAPI.Class02.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly List<User> _users = new List<User>()
        {
            new User
            {
                Id = 1,
                Name = "Trajan",
                Age = 33,
                Gender = "m"
            },
            new User
            {
                Id = 2,
                Name = "Vlatko",
                Age = 28,
                Gender = "m"
            },
            new User
            {
                Id = 3,
                Name = "Stefan",
                Age = 30,
                Gender = "m"
            },
            new User
            {
                Id = 4,
                Name = "Aneta",
                Age = 31,
                Gender = "f"
            },
            new User
            {
                Id = 5,
                Name = "Aleksandar",
                Age = 35,
                Gender = "m"
            }
        };

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            if(id < 1)
            {
                return BadRequest(id);
            }

            var user = _users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound($"The user with id {id} does not exists");
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpGet("{name}/age/{age}")]
        public ActionResult<IEnumerable<User>> GetUsersByNameAndAge(string name, int age)
        {
            var users = _users
                .Where(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                .Where(x => x.Age == age);

            return Ok(users);
        }

        [HttpGet("gender/{gender}/age/{age}")]
        public ActionResult<IEnumerable<User>> GetUsersByGenderAndAge(string gender, int age)
        {
            var users = _users
                .Where(x => x.Gender == gender)
                .Where(x => x.Age > age);

            return Ok(users);
        }
    }
}
