using System.ComponentModel.DataAnnotations;

namespace ExpenseGuardBackend.DTOs.Expense
{
	public record CreateExpenseDto
	(
		[Required] string Name,
		[Required] string Category,
		[Required] decimal Price,
		[Required] DateTime SpendDate
	);
}
