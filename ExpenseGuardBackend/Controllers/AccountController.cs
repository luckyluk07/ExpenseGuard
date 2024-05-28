using ExpenseGuardBackend.DTOs.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseGuardBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
        private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}

		[HttpPost]
		public async Task<ActionResult> Register([FromBody] RegisterDataDto body)
		{
			var user = new IdentityUser { UserName = body.Email, Email = body.Email };
			if (body.Password != body.RepeatPassword)
			{
				return BadRequest();
			}
			var createdUser = await _userManager.CreateAsync(user, body.Password);

			return Ok(createdUser);
		}
	}
}
