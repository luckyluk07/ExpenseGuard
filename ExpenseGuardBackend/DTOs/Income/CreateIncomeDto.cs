using System.ComponentModel.DataAnnotations;
using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.DTOs.Income
{
	public record CreateIncomeDto
	(
		[Required] string Name,
		[Required] DateTime ReceivedDate,
		[Required] decimal Amount,
		[Required] int CurrencyId,
		[Required] int CategoryId
	);
}
