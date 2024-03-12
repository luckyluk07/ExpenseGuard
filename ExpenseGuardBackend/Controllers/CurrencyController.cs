using ExpenseGuardBackend.DTOs.Currencies;
using ExpenseGuardBackend.Services.Currencies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseGuardBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CurrencyController : ControllerBase
	{
		private readonly ICurrencyService _currencyService;

		public CurrencyController(ICurrencyService currencyService)
		{
			_currencyService = currencyService;
		}

		[HttpGet]
		public ActionResult<List<CurrencyDto>> Get()
		{
			return Ok(_currencyService.GetCurrencies());
		}

		[HttpGet("{id}")]
		public ActionResult<CurrencyDto> Get(int id)
		{
			var currency = _currencyService.GetCurrency(id);
			if (currency is null)
			{
				return NotFound();
			}
			return Ok(currency);
		}
	}
}
