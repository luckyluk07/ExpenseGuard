using ExpenseGuardBackend.DTOs.Currencies;
using ExpenseGuardBackend.Services.Currencies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseGuardBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = "Bearer")]
	public class CurrencyController : ControllerBase
	{
		private readonly ICurrencyService _currencyService;

		public CurrencyController(ICurrencyService currencyService)
		{
			_currencyService = currencyService;
		}

		[HttpGet]
		public ActionResult<CurrenciesDto> Get()
		{
			return Ok(new CurrenciesDto(_currencyService.GetCurrencies()));
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
