using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreLibrary.DbModels;
using StoreLibrary.Models;

namespace StoreAPI.Controllers
{
	[Route("api/images")]
	[ApiController]
	public class ImagesController: ControllerBase
	{
		private readonly StoreDbContext _context;
		private readonly IWebHostEnvironment _env;

		public ImagesController(StoreDbContext context, IWebHostEnvironment env)
		{
			_context = context;
			_env = env;
		}

		[HttpGet("{imageCategory}/{ownerId}")]
		public async Task<ActionResult<IEnumerable<ImageDTO>>> GetImageDtoList(ImageCategory imageCategory, int ownerId)
		{
			List<ImageDTO> imageDtoList = new();

			if (imageCategory == ImageCategory.Product)
			{
				Product? product = await _context.Products
					.FirstOrDefaultAsync(p => p.PkProduct == ownerId);

				if (product == null)
					return NotFound("Produto não encontrado.");

				Image? mainImage = await _context.Images
					.FirstOrDefaultAsync(img => img.PkImage == product.FkImage);

				if (mainImage != null)
				{
					imageDtoList.Add(new ImageDTO
					{
						ImageId = mainImage.PkImage,
						PathImg = mainImage.PathImg,
						Name = mainImage.Name
					});
				}
			}
			else if (imageCategory == ImageCategory.ProductPage)
			{
				Product? product = await _context.Products
					.Include(p => p.FkImages)
					.FirstOrDefaultAsync(p => p.PkProduct == ownerId);

				if (product == null)
					return NotFound("Produto não encontrado.");

				imageDtoList = product.FkImages
					.Where(img => img.PkImage != product.FkImage)
					.Select(img => new ImageDTO
					{
						ImageId = img.PkImage,
						PathImg = img.PathImg,
						Name = img.Name
					})
					.ToList();
			}
			else if (imageCategory == ImageCategory.Campaign)
			{
				Campaign? campaign = await _context.Campaigns
					.Include(c => c.FkImages)
					.FirstOrDefaultAsync(c => c.PkCampaign == ownerId);

				if (campaign == null)
					return NotFound("Campanha não encontrada.");

				imageDtoList = campaign.FkImages
					.Select(img => new ImageDTO
					{
						ImageId = img.PkImage,
						PathImg = img.PathImg,
						Name = img.Name
					})
					.ToList();
			}
			else if (imageCategory == ImageCategory.Review)
			{
				Review? review = await _context.Reviews
					.Include(r => r.FkImages)
					.FirstOrDefaultAsync(r => r.PkReview == ownerId);

				if (review == null)
					return NotFound("Review não encontrada.");

				imageDtoList = review.FkImages
					.Select(img => new ImageDTO
					{
						ImageId = img.PkImage,
						PathImg = img.PathImg,
						Name = img.Name
					})
					.ToList();
			}
			else if (imageCategory == ImageCategory.User)
			{
				ImageDTO? userImage = await _context.UserImages
					.Where(ui => ui.FkUser == ownerId.ToString())
					.Join(_context.Images,
						  userImage => userImage.FkImage,
						  image => image.PkImage,
						  (userImage, image) => new ImageDTO
						  {
							  ImageId = image.PkImage,
							  PathImg = image.PathImg,
							  Name = image.Name
						  })
					.FirstOrDefaultAsync();

				if (userImage != null)
					imageDtoList.Add(userImage);
			}
			else
			{
				return BadRequest("Categoria de imagem inválida.");
			}

			return Ok(imageDtoList);
		}

		[HttpPost("{imageCategory}/{ownerId}")]
		public async Task<IActionResult> UploadImage(ImageCategory imageCategory, int ownerId, IFormFile file, [FromForm] string? name)
		{
			if (file == null || file.Length == 0)
				return BadRequest("Nenhum ficheiro enviado.");

			string extension = Path.GetExtension(file.FileName);
			if (!extension.Equals(".jpg") && !extension.Equals(".png"))
				return BadRequest("Tipo de ficheiro inválido.");

			string categoryFolderPath = Path.Combine(_env.WebRootPath, "Images", imageCategory.ToString());
			if (!Directory.Exists(categoryFolderPath))
				return BadRequest("Diretório de categoria não encontrado.");

			string ownerFolderPath = Path.Combine(categoryFolderPath, ownerId.ToString());
			if (!Directory.Exists(ownerFolderPath))
				Directory.CreateDirectory(ownerFolderPath);

			string originalName = Path.GetFileNameWithoutExtension(file.FileName);
			string uniqueSuffix = Guid.NewGuid().ToString("N").Substring(0, 5);
			string finalFileName = $"{originalName}_{uniqueSuffix}{extension}";
			string finalPath = Path.Combine(ownerFolderPath, finalFileName);

			using (var stream = new FileStream(finalPath, FileMode.Create))
			{
				try
				{
					await file.CopyToAsync(stream);
				}
				catch (Exception)
				{
					return StatusCode(500, "Erro inesperado, tente novamente.");
				}
			}

			string dbPath = $"/Images/{imageCategory}/{ownerId}/{finalFileName}";

			Image image = new Image
			{
				PathImg = dbPath,
				Name = !string.IsNullOrWhiteSpace(name) ? name : originalName
			};

			_context.Images.Add(image);

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (Exception)
			{
				return StatusCode(500, "Erro inesperado, tente novamente.");
			}

			if (imageCategory == ImageCategory.Product)
			{
				Product? product = await _context.Products
					.FirstOrDefaultAsync(p => p.PkProduct == ownerId);

				if (product == null)
					return NotFound("Produto não encontrado.");

				product.FkImage = image.PkImage;
			}
			else if (imageCategory == ImageCategory.ProductPage)
			{
				Product? product = await _context.Products
					.Include(p => p.FkImages)
					.FirstOrDefaultAsync(p => p.PkProduct == ownerId);

				if (product == null)
					return NotFound("Produto não encontrado.");

				product.FkImages.Add(image);
			}
			else if (imageCategory == ImageCategory.Campaign)
			{
				Campaign? campaign = await _context.Campaigns
					.Include(c => c.FkImages)
					.FirstOrDefaultAsync(c => c.PkCampaign == ownerId);

				if (campaign == null)
					return NotFound("Campanha não encontrada.");

				campaign.FkImages.Add(image);
			}
			else if (imageCategory == ImageCategory.Review)
			{
				Review? review = await _context.Reviews
					.Include(r => r.FkImages)
					.FirstOrDefaultAsync(r => r.PkReview == ownerId);

				if (review == null)
					return NotFound("Review não encontrada.");

				review.FkImages.Add(image);
			}
			else if (imageCategory == ImageCategory.User)
			{
				string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

				if (userId == null)
					return NotFound("Utilizador não encontrado.");

				UserImage? existingUserImage = await _context.UserImages.FirstOrDefaultAsync(ui => ui.FkUser == userId);

				if (existingUserImage != null)
				{
					existingUserImage.FkImage = image.PkImage;
				}
				else
				{
					UserImage userImage = new UserImage
					{
						FkUser = userId,
						FkImage = image.PkImage
					};
					_context.UserImages.Add(userImage);
				}
			}
			else
			{
				return BadRequest("Categoria de imagem inválida.");
			}

			try
			{
				await _context.SaveChangesAsync();

				return StatusCode(201, "Imagem adicionada com sucesso!");
			}
			catch (Exception)
			{
				return StatusCode(500, "Erro inesperado, tente novamente.");
			}
		}

		[HttpDelete("{imageId}")]
		public async Task<IActionResult> DeleteImage(int imageId)
		{
			Image? image = await _context.Images.FindAsync(imageId);

			if (image == null)
				return NotFound("Image not found.");

			string filePath = Path.Combine(_env.WebRootPath, image.PathImg.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
			if (System.IO.File.Exists(filePath))
			{
				System.IO.File.Delete(filePath);
			}

			_context.Images.Remove(image);

			try
			{
				await _context.SaveChangesAsync();

				return StatusCode(200, "Imagem removida com sucesso!");
			}
			catch (Exception)
			{
				return StatusCode(500, "Erro inesperado, tente novamente.");
			}
		}

		//[HttpPut("{imageCategory}/{ownerId}/{imageId}")]
		//public async Task<IActionResult> UpdateImage(ImageCategory imageCategory, int ownerId, int imageId, IFormFile file, [FromForm] string? name)
		//{
		//	var image = await _context.Images.FindAsync(imageId);

		//	if (image == null)
		//		return NotFound("Image not found.");

		//	if (file == null || file.Length == 0)
		//		return BadRequest("No file uploaded.");

		//	var categoryFolderPath = Path.Combine(_env.WebRootPath, "Images", imageCategory.ToString());
		//	if (!Directory.Exists(categoryFolderPath))
		//		return BadRequest("Category folder does not exist on the server.");

		//	// Build owner folder
		//	var ownerFolderPath = Path.Combine(categoryFolderPath, ownerId.ToString());
		//	if (!Directory.Exists(ownerFolderPath))
		//		Directory.CreateDirectory(ownerFolderPath);

		//	// Create new unique filename
		//	var originalName = Path.GetFileNameWithoutExtension(file.FileName);
		//	var extension = Path.GetExtension(file.FileName);
		//	var uniqueSuffix = Guid.NewGuid().ToString("N").Substring(0, 6);
		//	var finalFileName = $"{originalName}_{uniqueSuffix}{extension}";
		//	var finalPath = Path.Combine(ownerFolderPath, finalFileName);

		//	// Save new file
		//	using (var stream = new FileStream(finalPath, FileMode.Create))
		//	{
		//		await file.CopyToAsync(stream);
		//	}

		//	// Delete old file
		//	var oldFilePath = Path.Combine(_env.WebRootPath, image.PathImg.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
		//	if (System.IO.File.Exists(oldFilePath))
		//	{
		//		System.IO.File.Delete(oldFilePath);
		//	}

		//	// Update image record
		//	image.PathImg = $"/Images/{imageCategory}/{ownerId}/{finalFileName}";
		//	if (!string.IsNullOrWhiteSpace(name))
		//		image.Name = name;
		//	else
		//		image.Name = originalName;

		//	await _context.SaveChangesAsync();

		//	return Ok(new { path = image.PathImg });
		//}
	}
}

