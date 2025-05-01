using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using StoreLibrary.DbModels;
using StoreLibrary.Models;

namespace StoreAPI.Controllers
{
	[Route("api/products")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly StoreDbContext _context;
		private readonly IWebHostEnvironment _env;

		public ProductsController(StoreDbContext context, IWebHostEnvironment env)
		{
			_context = context;
			_env = env;
		}

		// GET: api/products/category/tecnologia
		[HttpGet("category/{category?}")]
		public async Task<ActionResult<List<ProductDTO>>> GetProductDtoList(string? category, [FromQuery] FilterDTO? filter, [FromQuery] string? search = null)
		{
			var query = _context.Products
				.Where(p => p.Toggle == true)
				.Include(p => p.FkCategories)
				.Include(p => p.FkImages)
				.AsQueryable();

			if (search != null)
			{
				query = query.Where(p =>
					p.Name.Contains(search) ||
					p.Description.Contains(search) ||
					p.Ean.Contains(search));
			}
			else
			{
				if (category != null)
				{
					query = query.Where(p => p.FkCategories.Any(c => c.Name.Equals(category, StringComparison.OrdinalIgnoreCase)));
				}
				if (filter != null)
				{
					if (filter.MinPrice != null)
						query = query.Where(p => p.Price >= filter.MinPrice.Value);
					if (filter.MaxPrice != null)
						query = query.Where(p => p.Price >= filter.MaxPrice.Value);
					if (filter.InStock == true)
						query = query.Where(p => p.Stock > 0);
					else if (filter.InStock == false)
						query = query.Where(p => (p.Stock == 0));
				}
			}

			DateOnly today = DateOnly.FromDateTime(DateTime.UtcNow);

			List<ProductDTO> productDtoList = await query
				.Select(p => new ProductDTO
				{
					ProductId = p.PkProduct,
					Ean = p.Ean,
					Name = p.Name,
					Category = p.FkCategories
						.OrderBy(c => c.PkCategory)
						.Select(c => c.Name)
						.FirstOrDefault() ?? string.Empty,
					Description = p.Description,
					Price = p.Price,
					Discount = p.CampaignProducts
						.Where(cp =>
							cp.FkCampaignNavigation.DateStart <= today &&
							cp.FkCampaignNavigation.DateEnd >= today)
						.OrderByDescending(cp => cp.FkCampaignNavigation.DateStart)
						.Select(cp => cp.Discount)
						.FirstOrDefault(),
					InStock = p.Stock > 0,
					IsFavorite = false,
					MainImage = p.FkImages
						.Select(img => new ImageDTO
						{
							ImageId = img.PkImage,
							PathImg = Path.Combine(_env.WebRootPath, img.PathImg.Substring(1)),
							Name = img.Name
						})
						.FirstOrDefault() ?? new ImageDTO()
				})
				.ToListAsync();

			if (productDtoList == null)
				return NotFound();

			string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			if (userId != null)
			{
				List<int> favoriteProductIds = await _context.Favourites
					.Where(f => f.FkUser == userId)
					.Select(f => f.FkProduct)
					.ToListAsync();

				foreach (ProductDTO productDto in productDtoList)
				{
					productDto.IsFavorite = favoriteProductIds.Contains(productDto.ProductId);
				}
			}

			return Ok(productDtoList);
		}

		[HttpGet("product/{ean}")]
		public async Task<ActionResult<ProductPageDTO>> GetProductPage(string ean)
		{
			Product? productEntity = await _context.Products
				.Where(p => p.Toggle && p.Ean == ean)
				.Include(p => p.FkCategories)
				.Include(p => p.FkImages)
				.Include(p => p.CampaignProducts)
					.ThenInclude(cp => cp.FkCampaignNavigation)
				.Include(p => p.PurchaseProducts)
					.ThenInclude(pp => pp.FkReviewNavigation)
						.ThenInclude(r => r.FkImages)
				.FirstOrDefaultAsync();

			if (productEntity == null)
				return NotFound();

			DateOnly today = DateOnly.FromDateTime(DateTime.UtcNow);

			ProductPageDTO product = new ProductPageDTO
			{
				ProductId = productEntity.PkProduct,
				Ean = productEntity.Ean,
				Name = productEntity.Name,
				Description = productEntity.Description,
				Price = productEntity.Price,
				InStock = productEntity.Stock > 0,
				Discount = productEntity.CampaignProducts
					.Where(cp => cp.FkCampaignNavigation != null &&
								 cp.FkCampaignNavigation.DateStart <= today &&
								 cp.FkCampaignNavigation.DateEnd >= today)
					.OrderByDescending(cp => cp.FkCampaignNavigation.DateStart)
					.Select(cp => cp.Discount)
					.FirstOrDefault(),
				Category = productEntity.FkCategories
					.OrderBy(c => c.PkCategory)
					.Select(c => c.Name)
					.FirstOrDefault() ?? string.Empty,
				IsFavorite = false,
				MainImage = productEntity.FkImages
					.Select(img => new ImageDTO
					{
						ImageId = img.PkImage,
						PathImg = Path.Combine(_env.WebRootPath, img.PathImg.Substring(1)),
						Name = img.Name
					})
					.FirstOrDefault() ?? new ImageDTO(),
				ImageDTOList = productEntity.FkImages
					.Where(img => img.PkImage != productEntity.FkImage)
					.Select(img => new ImageDTO
					{
						ImageId = img.PkImage,
						PathImg = Path.Combine(_env.WebRootPath, img.PathImg.Substring(1)),
						Name = img.Name
					})
					.ToList(),
				ReviewDTOList = productEntity.PurchaseProducts
					.Where(pp => pp.FkReviewNavigation != null)
					.Select(pp => new ReviewDTO
					{
						ReviewId = pp.FkReviewNavigation.PkReview,
						ReviewDate = pp.FkReviewNavigation.DataReview,
						Stars = pp.FkReviewNavigation.Stars,
						Comment = pp.FkReviewNavigation.Comment,
						ImageDTOList = pp.FkReviewNavigation.FkImages?.Select(img => new ImageDTO
						{
							ImageId = img.PkImage,
							PathImg = Path.Combine(_env.WebRootPath, img.PathImg.Substring(1)),
							Name = img.Name
						}).ToList() ?? new List<ImageDTO>()
					})
					.Distinct()
					.ToList()
			};

			string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			if (userId != null)
			{
				product.IsFavorite = await _context.Favourites
					.AnyAsync(f => f.FkUser == userId && f.FkProduct == product.ProductId);
			}

			return Ok(product);
		}
	}
}
