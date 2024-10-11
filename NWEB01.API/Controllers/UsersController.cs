using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NWEB01.Application.Services.UserService;
using NWEB01.Domain.Specifications;

namespace NWEB01.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService userService;

		public UsersController(IUserService userService)
		{
			this.userService = userService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] UserSpeParam userSpeParam)
		{
			var users = await userService.GetUsers(userSpeParam);
			return Ok(users);
		}
	}
}
