using ExpenseGuardBackend.DTOs.InvestmentDeposits;
using ExpenseGuardBackend.Services.InvestmentDeposits;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseGuardBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
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

		// todo consider refactoring or change parameters
		//[HttpDelete("{id}")]
		//public ActionResult<bool> Delete(int id, [FromHeader] int financeId)
		//{
		//	var investmentRemoved = _investmentDepositService.Remove(id, financeId);
		//	if (!investmentRemoved)
		//	{
		//		return NotFound();
		//	}

		//	return Ok(investmentRemoved);
		//}
	}
}
