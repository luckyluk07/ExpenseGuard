using ExpenseGuardBackend.DTOs.Categories;

namespace ExpenseGuardBackend.Services.Categories
{
	public interface ICategoryService
	{
		bool Delete(int id);
		List<CategoryDto> GetAll();
		CategoryDto? GetById(int id);
		CategoryDto Create(CreateCategoryDto createCategoryDto);
		CategoryDto Update(UpdateCategoryDto updateCategoryDto, int id);
	}
}