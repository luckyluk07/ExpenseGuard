using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseGuardBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExpenseController : ControllerBase
	{
		private readonly IExpenseRepository _expenseRepository;
		public ExpenseController(IExpenseRepository expenseRepository)
		{
			_expenseRepository = expenseRepository;
		}

		[HttpGet]
		public ActionResult<List<Expense>> Get()
		{
			return _expenseRepository.GetAll();
		}
	}
}
