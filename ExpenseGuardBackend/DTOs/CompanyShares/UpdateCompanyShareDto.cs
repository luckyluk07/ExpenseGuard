namespace ExpenseGuardBackend.DTOs.CompanyShares
{
	public record UpdateCompanyShareDto
	(
		string Name,
		DateTime DateOfPurchase,
		decimal SharesAmount,
	 	int Price,
		int CurrencyId
	);
}
