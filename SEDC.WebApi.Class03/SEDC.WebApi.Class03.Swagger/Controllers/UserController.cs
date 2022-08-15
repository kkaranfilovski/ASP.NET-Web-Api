using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.Class03.Swagger.Models;

namespace SEDC.WebApi.Class03.Swagger.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IEnumerable<User> _users = new List<User>
        {
            new User
            {
                Id = 1,
                Name = "Kristijan"
            }
        };

        /// <summary>
        /// Return all users
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_users);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<UserDto>> GetUsersByName(string name)
        {
            var userDto = _users.Select(x => new UserDto { UserId = x.Id, FullName = x.Name });
            return Ok(userDto);
        }

        [HttpGet("filter")]
        public ActionResult<IEnumerable<UserDto>> GetFilteredUsers([FromQuery] SearchInput input)
        {
            var userDto = _users.Select(x => new UserDto { UserId = x.Id, FullName = x.Name });
            return Ok(userDto);
        }

    }
}
