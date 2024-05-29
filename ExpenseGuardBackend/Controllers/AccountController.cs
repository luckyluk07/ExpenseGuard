using ExpenseGuardBackend.DTOs.Accounts;
using Microsoft.AspNetCore.Authorization;
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
		private readonly SignInManager<IdentityUser> _signInManager;
		public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<ActionResult> Register([FromBody] RegisterDataDto body)
		{
			var user = new IdentityUser { UserName = body.Email, Email = body.Email };
			if (body.Password != body.RepeatPassword)
			{
				return BadRequest();
			}
			var createdUser = await _userManager.CreateAsync(user, body.Password);
			if (createdUser.Succeeded)
			{
				await _signInManager.SignInAsync(user, false);
				return Ok(createdUser);
			}

			return BadRequest();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<ActionResult> Login([FromBody] LoginDataDto body)
		{
			var result = await _signInManager.PasswordSignInAsync(body.Email, body.Password, false, lockoutOnFailure: false);
			if (result.Succeeded)
			{
				return Ok(result);
			}
			return BadRequest();
		}

		[HttpPost]
		public async Task<ActionResult> Logout()
		{
			await _signInManager.SignOutAsync();

			return Ok();
		}
	}
}
