using ExpenseGuardBackend.DTOs.Finances;
using ExpenseGuardBackend.Services.Finances;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseGuardBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class FinanceController : ControllerBase
	{
		private readonly IFinanceService _financeService;

		public FinanceController(IFinanceService financeService)
		{
			_financeService = financeService;
		}

		[HttpGet]
		public ActionResult<FinancesDto> Get() 
		{
			return Ok(new FinancesDto(_financeService.GetFinances()));
		}

		[HttpGet("{id}")]
		public ActionResult<FinanceDto> Get(int id)
		{
			var finance = _financeService.GetFinance(id);
			if (finance is null)
			{
				return NotFound();
			}
			return Ok(finance);
		}


		[HttpPost]
		public ActionResult<FinanceDto> Create([FromBody] CreateFinanceDto createFinanceDto)
		{
			var newFinance = _financeService.Create(createFinanceDto);
			if (newFinance is null)
			{
				return BadRequest();
			}
			return Created($"{Url.Action(nameof(Create))}/{newFinance.Id}", newFinance);
		}

		// todo consider is it worth to have that endpoint
		//[HttpPut("{id}")]
		//public ActionResult<Expense> Update([FromBody] UpdateFinanceDto updateFinanceDto, int id)
		//{
		//	var updatedFinance = _financeService.Update(updateFinanceDto, id);
		//	if (updatedFinance is null)
		//	{
		//		return NotFound();
		//	}
		//	return Ok(updatedFinance);
		//}


		[HttpDelete("{id}")]
		public ActionResult<bool> Delete(int id)
		{
			var finance = _financeService.Remove(id);
			if (!finance)
			{
				return NotFound();
			}
			return Ok(finance);
		}
	}
}
