using Microsoft.AspNetCore.Identity;

namespace ExpenseGuardBackend.Models
{
	public class User : IdentityUser<string>
	{
        public int FinanceId { get; set; }
    }
}
