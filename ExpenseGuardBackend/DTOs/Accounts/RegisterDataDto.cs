namespace ExpenseGuardBackend.DTOs.Accounts
{
	public class RegisterDataDto
	{
		public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
	}
}
