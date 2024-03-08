using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Repositories.Categories
{
	public interface ICategoryRepository
	{
		Category Create(Category category);
		Category? Get(int id);
		List<Category> GetAll();
		bool Remove(int id);
		Category? Updated(Category category, int id);
	}
}