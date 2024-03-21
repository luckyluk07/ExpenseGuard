namespace ExpenseGuardBackend.Models
{
	public class InvestmentDeposit
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Money StartMoney { get; set; }
        public int YearCapitalizationAmount { get; set; }
        public decimal InterestRate { get; set; }
    }
}
