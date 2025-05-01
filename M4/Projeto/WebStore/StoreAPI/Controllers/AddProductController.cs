using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreLibrary.DbModels;
using StoreLibrary.DTOs.Product;

namespace StoreAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AddProductController : ControllerBase
	{
		private readonly StoreDbContext _context;

		public AddProductController(StoreDbContext context)
		{
			_context = context;
		}

		[HttpPost]
		public async Task<IActionResult> AddProduct([FromBody] AddProductDTO productDto)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(productDto.Name) ||
					string.IsNullOrWhiteSpace(productDto.Description) ||
					productDto.Price <= 0 ||
					string.IsNullOrWhiteSpace(productDto.Ean) ||
					productDto.ImageId <= 0 ||
					productDto.CategoryId <= 0)
				{
					return BadRequest("Invalid data provided.");
				}

				var image = await _context.Images.FirstOrDefaultAsync(i => i.PkImage == productDto.ImageId);
				if (image == null)
				{
					return NotFound($"Image with ID {productDto.ImageId} not found.");
				}

				var category = await _context.Categories.FirstOrDefaultAsync(c => c.PkCategory == productDto.CategoryId);
				if (category == null)
				{
					return NotFound($"Category with ID {productDto.CategoryId} not found.");
				}

				var product = new Product
				{
					Name = productDto.Name,
					Description = productDto.Description,
					Price = productDto.Price,
					Stock = productDto.Stock,
					Toggle = true,
					Ean = productDto.Ean,
					FkImage = productDto.ImageId,
					FkCategories = new List<Category> { category }
				};

				_context.Products.Add(product);
				await _context.SaveChangesAsync();

				return Ok(new
				{
					product.PkProduct,
					product.Name,
					product.Description,
					product.Price,
					product.Stock,
					product.FkImage,
					product.Ean
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
	}
}
