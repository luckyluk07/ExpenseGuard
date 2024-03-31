using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Repositories.Categories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly ExpenseGuardDbContext _expenseGuardDbContext;

		public CategoryRepository(ExpenseGuardDbContext expenseGuardDbContext)
		{
			_expenseGuardDbContext = expenseGuardDbContext;
		}

		public Category Create(Category category)
		{
			var newCategory = new Category()
			{
				Name = category.Name,
				Description = category.Description
			};
			_expenseGuardDbContext.Categories.Add(newCategory);
			_expenseGuardDbContext.SaveChanges();
			return newCategory;
		}

		public Category? Get(int id)
		{
			return _expenseGuardDbContext.Categories
				.FirstOrDefault(c => c.Id == id);
		}

		public List<Category> GetAll()
		{
			return _expenseGuardDbContext.Categories.ToList();
		}

		public bool Remove(int id)
		{
			var categoryToRemove = Get(id);
			if (categoryToRemove is null)
			{
				return false;
			}
			_expenseGuardDbContext.Categories.Remove(categoryToRemove);
			_expenseGuardDbContext.SaveChanges();
			return true;
		}

		public Category? Updated(Category category, int id)
		{
			var categoryToUpdate = Get(id);
			if (categoryToUpdate is null)
			{
				return null;
			}
			categoryToUpdate.Name = category.Name;
			categoryToUpdate.Description = category.Description;
			_expenseGuardDbContext.SaveChanges();
			return categoryToUpdate;
		}
	}
}
