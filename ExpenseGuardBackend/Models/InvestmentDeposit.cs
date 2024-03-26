namespace ExpenseGuardBackend.Models
{
	public class InvestmentDeposit
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int YearCapitalizationAmount { get; set; }
        public decimal InterestRate { get; set; }

		public Money StartMoney { get; set; }
        public int StartMoneyId { get; set; }

		public Finance Finance { get; set; }
        public int FinanceId { get; set; }
    }
}
