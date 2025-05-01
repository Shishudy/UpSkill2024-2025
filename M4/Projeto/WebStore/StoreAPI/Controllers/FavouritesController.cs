using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreLibrary.DbModels;
using StoreLibrary.Models;

namespace StoreAPI.Controllers
{
	[Route("api/favourites")]
	[ApiController]
	public class FavouritesController: ControllerBase
	{
		private readonly StoreDbContext _context;

		public FavouritesController(StoreDbContext context)
		{
			_context = context;
		}

		[HttpPost("{productId}")]
		public async Task<ActionResult<string>> UpdateFavourites(int productId)
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			if (string.IsNullOrEmpty(userId))
				return Unauthorized("User not signed in!");

			var favourite = await _context.Favourites.FirstOrDefaultAsync(f => f.FkUser == userId && f.FkProduct == productId);

			string msg;

			if (favourite == null)
			{
				favourite = new Favourite
				{
					FkProduct = productId,
					FkUser = userId
				};
				_context.Favourites.Add(favourite);
				msg = "Produto adicionado aos favoritos!";
			}
			else
			{
				_context.Favourites.Remove(favourite);
				msg = "Produto removido dos favoritos!";
			}

			try
			{
				await _context.SaveChangesAsync();
				return Ok(msg);
			}
			catch (Exception)
			{
				return StatusCode(500, "Error ao atualizar favoritos.");
			}
		}
	}
}
