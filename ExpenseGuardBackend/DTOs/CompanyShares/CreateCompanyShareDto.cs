namespace ExpenseGuardBackend.DTOs.CompanyShares
{
	public record CreateCompanyShareDto
	(
		string Name,
		DateTime DateOfPurchase,
		decimal SharesAmount,
	 	int Price,
		int CurrencyId
	);
}
