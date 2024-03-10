using ExpenseGuardBackend.DTOs.Categories;

namespace ExpenseGuardBackend.DTOs.Expense
{
	public record ExpenseDto
	(
		int Id,
		string Name,
		CategoryDto Category,
		decimal Price,
		DateTime SpendDate
	);
}
