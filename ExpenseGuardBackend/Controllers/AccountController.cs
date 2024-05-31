using ExpenseGuardBackend.DTOs.Accounts;
using ExpenseGuardBackend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseGuardBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
        private readonly UserManager<User> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}

		[HttpPost("register")]
		public async Task<ActionResult> Register([FromBody] RegisterDataDto body)
		{
			var user = new User { UserName = body.Email, Email = body.Email };
			if (body.Password != body.RepeatPassword)
			{
				return BadRequest();
			}
			var createdUser = await _userManager.CreateAsync(user, body.Password);
			if (createdUser.Succeeded)
			{
				return Ok(createdUser);
			}

			return BadRequest();
		}

		[HttpPost("login")]
		public async Task<ActionResult> Login([FromBody] LoginDataDto body)
		{
			//todo add generating tokens
			var user = await _userManager.FindByEmailAsync(body.Email);
			var isPasswordValid = await _userManager.CheckPasswordAsync(user, body.Password);
			if (isPasswordValid)
			{
				return Ok();
			}
			return BadRequest();
		}
	}
}
