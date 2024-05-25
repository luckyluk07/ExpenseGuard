using ExpenseGuardBackend.DTOs.Money;

namespace ExpenseGuardBackend.DTOs.Accounts
{
	public class RegisterDataDto
	{
        public string Name { get; set; }
        public string Surname { get; set; }
		public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
		IEnumerable<CreateMoneyDto> CurrencySavings

	}
}
