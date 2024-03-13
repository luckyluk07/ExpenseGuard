using ExpenseGuardBackend.DTOs.Categories;
using ExpenseGuardBackend.DTOs.Money;

namespace ExpenseGuardBackend.DTOs.Income
{
	public record IncomeDto
	(
		int Id,
		string Name,
		DateTime ReceivedDate,
		MoneyDto Money,
		CategoryDto Category
	);
}
