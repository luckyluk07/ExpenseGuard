using ExpenseGuardBackend.DTOs.CompanyShares;
using ExpenseGuardBackend.Services.CompanyShares;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseGuardBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = "Bearer")]
	public class CompanyShareController : ControllerBase
	{
		private readonly ICompanyShareService _companyShareService;

		public CompanyShareController(ICompanyShareService companyShareService)
		{
			_companyShareService = companyShareService;
		}

		[HttpGet]
		public ActionResult<CompanySharesDto> GetAll()
		{
			return Ok(new CompanySharesDto(_companyShareService.GetAll()));
		}

		[HttpGet("{id}")]
		public ActionResult<CompanyShareDto> Get(int id)
		{
			var comapnyShare = _companyShareService.Get(id);
			if (comapnyShare is null)
			{
				return NotFound();
			}
			return Ok(comapnyShare);
		}

		[HttpPost]
		public ActionResult<CompanyShareDto> Create(CreateCompanyShareDto createCompanyShareDto)
		{
			var newCompanyShare = _companyShareService.Create(createCompanyShareDto);
			if (newCompanyShare is null)
			{
				return BadRequest();
			}
			return Created($"{Url.Action(nameof(Create))}/{newCompanyShare.Id}", newCompanyShare);
		}

		[HttpPut("{id}")]
		public ActionResult<CompanyShareDto> Update(UpdateCompanyShareDto updateCompanyShareDto, int id)
		{
			var updatedCompanyShare = _companyShareService.Update(updateCompanyShareDto, id);
			if (updatedCompanyShare is null)
			{
				return NotFound();
			}
			return Ok(updatedCompanyShare);
		}

		[HttpDelete("{id}")]
		public ActionResult<bool> Remove(int id)
		{
			var isCompanyShareRemoved = _companyShareService.Remove(id);
			if (!isCompanyShareRemoved)
			{
				return NotFound();
			}
			return Ok(isCompanyShareRemoved);
		}
	}
}
