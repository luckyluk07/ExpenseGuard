using ExpenseGuardBackend.DTOs.InvestmentDeposits;
using ExpenseGuardBackend.Services.InvestmentDeposits;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseGuardBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = "Bearer")]
	public class InvestmentDepositController : ControllerBase
	{
		private readonly IInvestmentDepositService _investmentDepositService;

		public InvestmentDepositController(IInvestmentDepositService investmentDepositService)
		{
			_investmentDepositService = investmentDepositService;
		}

		[HttpGet]
		public ActionResult<InvestmentDepositsDto> GetAll()
		{
			return Ok(new InvestmentDepositsDto(_investmentDepositService.GetAll()));
		}

		[HttpGet("{id}")]
		public ActionResult<InvestmentDepositDto> Get(int id)
		{
			var investment = _investmentDepositService.Get(id);
			if (investment is null)
			{
				return NotFound();
			}

			return Ok(investment);
		}

		[HttpPost]
		public ActionResult<InvestmentDepositDto> Create([FromBody] CreateInvestmentDepositDto createInvestmentDepositDto)
		{
			var createdInvestment = _investmentDepositService.Create(createInvestmentDepositDto);
			if (createdInvestment is null)
			{
				return BadRequest();
			}
			return Created($"{Url.Action(nameof(Create))}/{createdInvestment.Id}", createdInvestment);
		}

		[HttpPut("{id}")]
		public ActionResult<InvestmentDepositDto> Update([FromBody] UpdateInvestmentDepositDto updateInvestmentDepositDto, int id)
		{
			var updatedInvestmentDeposit = _investmentDepositService.Update(updateInvestmentDepositDto, id);
			if (updatedInvestmentDeposit is null)
			{
				return NotFound();
			}
			return Ok(updatedInvestmentDeposit);
		}

		[HttpDelete("{id}")]
		public ActionResult<bool> Delete(int id)
		{
			var investmentRemoved = _investmentDepositService.Remove(id);
			if (!investmentRemoved)
			{
				return NotFound();
			}

			return Ok(investmentRemoved);
		}
	}
}
