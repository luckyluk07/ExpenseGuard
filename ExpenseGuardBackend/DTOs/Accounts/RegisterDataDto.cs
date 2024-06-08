namespace ExpenseGuardBackend.DTOs.Accounts
{
	public record RegisterDataDto
	(
		string Email,
		string Password,
		string RepeatPassword
	);
}
