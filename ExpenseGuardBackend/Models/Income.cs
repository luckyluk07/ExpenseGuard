namespace ExpenseGuardBackend.Models
{
	public class Income
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReceivedDate { get; set; }
        public decimal Amount { get; set; }
	}
}
