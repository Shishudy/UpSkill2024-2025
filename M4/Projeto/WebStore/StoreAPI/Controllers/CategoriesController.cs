using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreLibrary.DbModels;
using StoreLibrary.Models;

namespace StoreAPI.Controllers
{
	[Route("api/categories")]
	[ApiController]
	public class CategoriesController: ControllerBase
	{
		private readonly StoreDbContext _context;

		public CategoriesController(StoreDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<CategoryDTO>>> GetCategoryDtoList()
		{
			var query = _context.Categories
				.AsQueryable();

			List<CategoryDTO> categoryDtoList = await query
				.Select(c => new CategoryDTO
				{
					CategoryId = c.PkCategory,
					Name = c.Name
				})
				.ToListAsync();

			if (categoryDtoList == null)
				return NotFound("Categoria não encontrada!");

			return Ok(categoryDtoList);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<CategoryDTO>> GetCategoryDtoById(int id)
		{
			var category = await _context.Categories.FindAsync(id);

			if (category == null)
				return NotFound("Categoria não encontrada!");

			CategoryDTO categoryDto = new CategoryDTO
			{
				CategoryId = category.PkCategory,
				Name = category.Name
			};

			return Ok(categoryDto);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategory(CategoryDTO categoryDto)
		{
			if (categoryDto.Name == null)
				return BadRequest();

			_ = categoryDto.Name.Trim();

			_ = char.ToUpper(categoryDto.Name[0]) + categoryDto.Name.Substring(1).ToLower();

			if (await _context.Categories.AnyAsync(c => c.Name == categoryDto.Name) == true)
				return Conflict();

			Category newCategory = new Category
			{
				Name = categoryDto.Name
			};

			_context.Categories.Add(newCategory);

			try
			{
				await _context.SaveChangesAsync();

				return StatusCode(201, "Categoria adicionada com sucesso!");
			}
			catch (Exception)
			{
				return StatusCode(500, "Error inesperado, tente novamente.");
			}
		}

		[HttpPut("{categoryId}")]
		public async Task<IActionResult> UpdateCategory(int categoryId, CategoryDTO categoryDto)
		{
			if (categoryId != categoryDto.CategoryId)
				return BadRequest("IDs não coincidem!");

			if (categoryDto.Name == null)
				return BadRequest();

			var category = await _context.Categories.FindAsync(categoryId);

			if (category == null)
				return NotFound("Categoria não encontrada!");

			_ = categoryDto.Name.Trim();

			_ = char.ToUpper(categoryDto.Name[0]) + categoryDto.Name.Substring(1).ToLower();

			if (await _context.Categories.AnyAsync(c => c.Name == categoryDto.Name) == true)
				return Conflict();

			category.Name = categoryDto.Name;

			try
			{
				await _context.SaveChangesAsync();
				return Ok("Categoria atualizada com sucesso!");
			}
			catch (Exception)
			{
				return StatusCode(500, "Erro inesperado, tente novamente.");
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCategory(int id)
		{
			var category = await _context.Categories.FindAsync(id);

			if (category == null)
				return NotFound("Category not found.");

			_context.Categories.Remove(category);

			try
			{
				await _context.SaveChangesAsync();
				return Ok("Categoria eliminada com sucesso!");
			}
			catch (Exception)
			{
				return StatusCode(500, "Erro inesperado, tente novamente.");
			}
		}
	}
}
