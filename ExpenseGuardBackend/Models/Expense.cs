namespace ExpenseGuardBackend.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public DateTime SpendDate { get; set; }
        public string Name { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public Money Money { get; set; }
        public int MoneyId { get; set; }

        public Finance Finance { get; set; }
        public int FinanceId { get; set; }
	}
}
