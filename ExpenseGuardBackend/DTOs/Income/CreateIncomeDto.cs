using System.ComponentModel.DataAnnotations;

namespace ExpenseGuardBackend.DTOs.Income
{
	public record CreateIncomeDto
	(
		[Required] string Name,
		[Required] DateTime ReceivedDate,
		[Required] decimal Amount
	);
}
