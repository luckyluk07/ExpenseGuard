using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Repositories.Categories
{
	public class CategoryRepository : ICategoryRepository
	{
		private int _lastUsedId;
		private List<Category> _categories;
		public CategoryRepository()
		{
			_lastUsedId = 1;
			_categories = new List<Category>();
			var category1 = new Category()
			{
				Name = "Food",
				Description = "Expense connected with food for breakfast, lunch and dinner"
			};
			var category2 = new Category()
			{
				Name = "City",
				Description = "Expenses connected with going out to the restaurant, discos and bars"
			};
			Create(category1);
			Create(category2);
		}

		public List<Category> GetAll()
		{
			return _categories;
		}

		public Category? Get(int id)
		{
			return _categories.FirstOrDefault(x => x.Id == id);
		}

		public Category Create(Category category)
		{
			var newCategory = new Category()
			{
				Id = _lastUsedId++,
				Name = category.Name,
				Description = category.Description
			};
			_categories.Add(newCategory);
			return newCategory;
		}

		public Category? Updated(Category category, int id)
		{
			var categoryToUpdate = _categories.FirstOrDefault(x => x.Id == id);
			if (categoryToUpdate is null)
			{
				return null;
			}
			categoryToUpdate.Name = category.Name;
			categoryToUpdate.Description = category.Description;
			return categoryToUpdate;
		}

		public bool Remove(int id)
		{
			var categoryToRemove = _categories.FirstOrDefault(x => x.Id == id);
			if (categoryToRemove is null)
			{
				return false;
			}
			_categories.Remove(categoryToRemove);
			return true;
		}
	}
}
