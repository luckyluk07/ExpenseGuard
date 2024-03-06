using ExpenseGuardBackend.DTOs.Expense;
using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseGuardBackend.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class ExpenseController : ControllerBase
	{
		private readonly IExpenseService _expenseService;
		public ExpenseController(IExpenseService expenseService)
		{
			_expenseService = expenseService;
		}

		[HttpGet]
		public ActionResult<List<Expense>> Get()
		{
			var expenses = _expenseService.GetAll();
			return Ok(expenses);
		}

		[HttpGet("{id}")]
		public ActionResult<Expense> Get(int id)
		{
			var expense = _expenseService.Get(id);
			if (expense is null)
			{
				return NotFound();
			}
			return Ok(expense);
		}

		[HttpPost]
		public ActionResult<Expense> Create([FromBody] CreateExpenseDto expense)
		{
			var newExpense = _expenseService.Create(expense);
			if (newExpense is null)
			{
				return BadRequest();
			}
			return Created("todo complete URI", newExpense);
		}

		[HttpPut("{id}")]
		public ActionResult<Expense> Put([FromBody] UpdateExpenseDto expense, int id)
		{
			var updatedExpense = _expenseService.Update(expense, id);
			if (updatedExpense is null)
			{
				return NotFound();
			}
			return Ok(updatedExpense);
		}

		[HttpDelete("{id}")]
		public ActionResult<bool> Delete(int id)
		{
			var isDeleted = _expenseService.Delete(id);
			if (!isDeleted)
			{
				return NotFound();
			}
			return Ok(isDeleted);
		}
	}
}
