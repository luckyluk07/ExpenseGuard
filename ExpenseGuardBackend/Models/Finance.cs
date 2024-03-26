namespace ExpenseGuardBackend.Models
{
	public class Finance
	{
        public int Id { get; set; }
        public ICollection<Money> CurrencySavings { get; set; }
        public ICollection<Income> Incomes { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<InvestmentDeposit> Investments { get; set; }
    }
}
