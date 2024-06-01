using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ExpenseGuardBackend.DTOs.Accounts;
using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ExpenseGuardBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[AllowAnonymous]
	public class AccountController : ControllerBase
	{
        private readonly UserManager<User> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IConfiguration _configuration;
		public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_configuration = configuration;
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
				var token = GenerateToken(user);
				return Ok(token);
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
				var token = GenerateToken(user);
				return Ok();
			}
			return BadRequest();
		}

		private string GenerateToken(User user)
		{
			var jwtSettings = (JwtSettings)_configuration.GetSection("Jwt");
			var key = Encoding.ASCII.GetBytes(jwtSettings.Key);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
				new Claim("Id", Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
				new Claim(JwtRegisteredClaimNames.Email, user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti,
				Guid.NewGuid().ToString())
			}),
				Expires = DateTime.UtcNow.AddMinutes(5),
				Issuer = jwtSettings.Issuer,
				Audience = jwtSettings.Audience,
				SigningCredentials = new SigningCredentials
				(new SymmetricSecurityKey(key),
				SecurityAlgorithms.HmacSha512Signature)
			};
			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescriptor);
			var jwtToken = tokenHandler.WriteToken(token);
			var stringToken = tokenHandler.WriteToken(token);
			return stringToken;
		}
	}
}
