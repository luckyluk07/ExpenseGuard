namespace ExpenseGuardBackend.Models
{
	public class Money
	{
		public int Id { get; set; }
		public decimal Amount { get; set; }

		public Currency Currency { get; set; }
		public int CurrencyId { get; set; }
	}
}
