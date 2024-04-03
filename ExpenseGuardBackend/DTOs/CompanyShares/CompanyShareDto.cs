using ExpenseGuardBackend.DTOs.Money;

namespace ExpenseGuardBackend.DTOs.CompanyShares
{
	public record CompanyShareDto
	(        
		int Id,
		string Name,
		DateTime DateOfPurchase,
		decimal Amount,
	 	MoneyDto Price
	);
}
