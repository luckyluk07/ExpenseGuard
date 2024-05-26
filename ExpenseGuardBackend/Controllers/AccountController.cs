using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseGuardBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpPost]
		public async Task<ActionResult> Register(string email, string username, string password)
		{
			var user = new IdentityUser { UserName = username, Email = email };
			var createdUser = await _userManager.CreateAsync(user, password);
			if (createdUser.Succeeded)
			{
				await _signInManager.SignInAsync(user, isPersistent: false);
			}

			return Ok();
		}
	}
}
