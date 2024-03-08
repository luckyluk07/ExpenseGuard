using ExpenseGuardBackend.DTOs.Categories;
using ExpenseGuardBackend.Services.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseGuardBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		public ActionResult<List<CategoryDto>> GetAll()
		{
			return Ok(_categoryService.GetAll());
		}

		[HttpGet("{id}")]
		public ActionResult<CategoryDto> Get(int id)
		{
			var category = _categoryService.GetById(id);
			if (category is null)
			{
				return NotFound();
			}
			return Ok(category);
		}

		[HttpDelete("{id}")]
		public ActionResult<bool> Delete(int id)
		{
			var isRemoved = _categoryService.Delete(id);
			if (!isRemoved)
			{
				return NotFound();
			}
			return Ok(true);
		}
	}
}
