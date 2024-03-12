namespace ExpenseGuardBackend.DTOs.Currencies
{
	public record CurrencyDto
	(
		int Id,
		string Name,
		string Code, 
		string Country
	);
}
