﻿namespace ExpenseGuardBackend.Models
{
	public class CompanyShare
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public decimal Amount { get; set; }

        public Money Price { get; set; }
        public int PriceId { get; set; }

        // todo add below and modify methods
        //public Finance finance { get; set; }
        //public int FinanceId { get; set; }
    }
}
