using ExpenseGuardBackend.DTOs.Categories;
using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories.Categories;
using ExpenseGuardBackend.Mappers;

namespace ExpenseGuardBackend.Services.Categories
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly EntityMapper _entityMapper;

		public CategoryService(ICategoryRepository categoryRepository, EntityMapper entityMapper)
		{
			_categoryRepository = categoryRepository;
			_entityMapper = entityMapper;
		}

		public List<CategoryDto> GetAll()
		{
			return _categoryRepository
				.GetAll()
				.Select(DtoMapper.CategoryToDto)
				.ToList();
		}

		public CategoryDto? GetById(int id)
		{
			var category = _categoryRepository.Get(id);
			if (category is null)
			{
				return null;
			}
			return DtoMapper.CategoryToDto(category);
		}

		public CategoryDto Create(CreateCategoryDto createCategoryDto)
		{
			var category = _entityMapper.CreateCategoryDtoToCategory(createCategoryDto);		
			var createdCategory = _categoryRepository.Create(category);
			return DtoMapper.CategoryToDto(createdCategory);
		}

		public CategoryDto Update(UpdateCategoryDto updateCategoryDto, int id)
		{
			var category = _entityMapper.UpdateCategoryDtoToCategory(updateCategoryDto);

			var updatedCategory = _categoryRepository.Updated(category, id);
			if (updatedCategory is null)
			{
				return null;
			}
			return DtoMapper.CategoryToDto(updatedCategory);
		}

		public bool Delete(int id)
		{
			return _categoryRepository.Remove(id);
		}
	}
}
