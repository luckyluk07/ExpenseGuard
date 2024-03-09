using ExpenseGuardBackend.DTOs.Categories;
using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories.Categories;

namespace ExpenseGuardBackend.Services.Categories
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoryService(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public List<CategoryDto> GetAll()
		{
			return _categoryRepository
				.GetAll()
				.Select(CategoryToDto)
				.ToList();
		}

		public CategoryDto? GetById(int id)
		{
			var category = _categoryRepository.Get(id);
			if (category is null)
			{
				return null;
			}
			return CategoryToDto(category);
		}

		public CategoryDto Create(CreateCategoryDto createCategoryDto)
		{
			var category = new Category()
			{
				Name = createCategoryDto.Name,
				Description = createCategoryDto.Description
			};
			
			var createdCategory = _categoryRepository.Create(category);
			return CategoryToDto(createdCategory);
		}

		public CategoryDto Update(UpdateCategoryDto updateCategoryDto, int id)
		{
			var category = new Category()
			{
				Name = updateCategoryDto.Name,
				Description = updateCategoryDto.Description
			};

			var updatedCategory = _categoryRepository.Updated(category, id);
			if (updatedCategory is null)
			{
				return null;
			}
			return CategoryToDto(updatedCategory);
		}

		public bool Delete(int id)
		{
			return _categoryRepository.Remove(id);
		}

		private CategoryDto CategoryToDto(Category category)
		{
			return new CategoryDto(category.Id, category.Name, category.Description);
		}

	}
}
