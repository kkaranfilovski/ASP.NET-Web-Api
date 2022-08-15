using Microsoft.AspNetCore.Mvc;

namespace SEDC.WebAPI.Class02.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FirstController : ControllerBase
    {
        private List<string> _names = new List<string>
        {
            "Trajan",
            "Vlatko,",
            "Stefan",
            "Aneta",
            "Aleksandar"
        };

        [HttpGet("random")]
        public int GetRandomInteger()
        {
            Random random = new Random();
            var a = random.Next(1, 100);
            return a;
        }

        [HttpGet("name/{id}")]
        public ActionResult GetName(int id)
        {
            try
            {
                var name = _names[id];
                return Ok(name);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
