using ExpenseGuardBackend.DTOs.Finances;
using ExpenseGuardBackend.Services.Finances;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseGuardBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FinanceController : ControllerBase
	{
		private readonly IFinanceService _financeService;

		public FinanceController(IFinanceService financeService)
		{
			_financeService = financeService;
		}

		[HttpGet]
		public ActionResult<List<FinanceDto>> Get() 
		{
			return Ok(_financeService.GetFinances());
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
