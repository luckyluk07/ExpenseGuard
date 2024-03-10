using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.DTOs.Income
{
	public record UpdateIncomeDto
	(
		DateTime ReceivedDate,
		decimal Amount,
		int CategoryId
	);
}
