using ExpenseGuardBackend.DTOs.Categories;
using ExpenseGuardBackend.DTOs.Money;

namespace ExpenseGuardBackend.DTOs.Expense
{
	public record ExpenseDto
	(
		int Id,
		string Name,
		CategoryDto Category,
		MoneyDto Money,
		DateTime SpendDate
	);
}
