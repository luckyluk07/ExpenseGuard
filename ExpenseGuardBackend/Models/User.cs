using Microsoft.AspNetCore.Identity;

namespace ExpenseGuardBackend.Models
{
	public class User : IdentityUser
	{
        public int FinanceId { get; set; }
    }
}
