using System.ComponentModel.DataAnnotations;

namespace ExpenseGuardBackend.DTOs.Expense
{
	public record CreateExpenseDto
	(
		[Required] string Name,
		[Required] int CategoryId,
		[Required] decimal Price,
		[Required] DateTime SpendDate
	);
}
