namespace ExpenseGuardBackend.Models
{
	public class Income : ICloneable
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReceivedDate { get; set; }
        public decimal Amount { get; set; }

		public object Clone()
		{
			return new Income()
			{
				Id = Id,
				Name = Name,
				ReceivedDate = ReceivedDate,
				Amount = Amount
			};
		}
	}
}
