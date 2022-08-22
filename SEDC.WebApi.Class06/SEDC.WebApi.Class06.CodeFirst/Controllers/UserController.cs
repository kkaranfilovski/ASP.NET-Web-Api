using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.Class06.CodeFirst.Domain;

namespace SEDC.WebApi.Class06.CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet("users")]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            var context = new PizzaDbContext();
            var user = context.Users.FirstOrDefault();
            return Ok(user);
        }
    }
}
