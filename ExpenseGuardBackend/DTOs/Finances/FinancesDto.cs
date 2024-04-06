namespace ExpenseGuardBackend.DTOs.Finances
{
	public record FinancesDto
	(
		IEnumerable<FinanceDto> Finances
	);
}
