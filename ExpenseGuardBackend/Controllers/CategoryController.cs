using ExpenseGuardBackend.DTOs.Categories;
using ExpenseGuardBackend.Services.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseGuardBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		public ActionResult<CategoriesDto> GetAll()
		{
			return Ok(new CategoriesDto(_categoryService.GetAll()));
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

		[HttpPost]
		public ActionResult<CategoryDto> Create(CreateCategoryDto category)
		{
			var createdCategory = _categoryService.Create(category);
			if (createdCategory is null)
			{
				return BadRequest();
			}
			return Created($"{Url.Action(nameof(Create))}/{createdCategory.Id}", createdCategory);
		}

		[HttpPut("{id}")]
		public ActionResult<CategoryDto> Update(UpdateCategoryDto category, int id) 
		{
			var updatedCategory = _categoryService.Update(category, id);
			if (updatedCategory is null)
			{
				return NotFound();
			}
			return Ok(updatedCategory);
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
