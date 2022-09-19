using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.Notes.ServiceModels.UserModels;
using SEDC.WebApi.Notes.Services.Interfaces;

namespace SEDC.WebApi.Notes.Api.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult RegisterUser([FromBody]RegisterUser request)
        {
            try
            {
                _userService.Register(request);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
