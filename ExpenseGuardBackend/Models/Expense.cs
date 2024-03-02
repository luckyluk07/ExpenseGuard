namespace ExpenseGuardBackend.Models
{
    public class Expense : ICloneable
    {
        public int Id { get; set; }
        public DateTime SpendDate { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

		public object Clone()
		{
            return new Expense()
            {
                Id = Id,
                SpendDate = SpendDate,
                Name = Name,
                Category = Category,
                Price = Price
            };
		}
	}
}
