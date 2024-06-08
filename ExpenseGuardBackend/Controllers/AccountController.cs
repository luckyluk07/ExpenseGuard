using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ExpenseGuardBackend.DTOs.Accounts;
using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
		private readonly JwtSettings _jwtSettings;

		public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IOptions<JwtSettings> jwtSettings)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_jwtSettings = jwtSettings.Value;
		}

		[HttpPost("Register")]
		public async Task<ActionResult<JwtTokenDto>> Register([FromBody] RegisterDataDto body)
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
				var dto = new JwtTokenDto(token);
				return Ok(dto);
			}

			return BadRequest();
		}

		[HttpPost("Login")]
		public async Task<ActionResult<JwtTokenDto>> Login([FromBody] LoginDataDto body)
		{
			var user = await _userManager.FindByEmailAsync(body.Email);
			var isPasswordValid = await _userManager.CheckPasswordAsync(user, body.Password);
			if (isPasswordValid)
			{
				var token = GenerateToken(user);
				var dto = new JwtTokenDto(token);
				return Ok(dto);
			}
			return BadRequest();
		}

		private string GenerateToken(User user)
		{
			var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(
				[
				new Claim("Id", Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
				new Claim(JwtRegisteredClaimNames.Email, user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti,
				Guid.NewGuid().ToString())
			]),
				Expires = DateTime.UtcNow.AddMinutes(5),
				Issuer = _jwtSettings.Issuer,
				Audience = _jwtSettings.Audience,
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
