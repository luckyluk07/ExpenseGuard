namespace ExpenseGuardBackend.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public DateTime SpendDate { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
	}
}
