namespace ExpenseGuardBackend.Models
{
	public class Finance
	{
        public int Id { get; set; }
        public List<Money> CurrencySavings { get; set; }
        public List<Income> Incomes { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}
