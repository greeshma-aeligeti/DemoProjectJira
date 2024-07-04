using DemoJira.Bussiness.DTO;
using DemoJira.Bussiness.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace Practice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("users")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var Users=await _userService.GetAllUsers();
            return Ok(Users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByID(id);
            return Ok(user);
        }

    }
}
