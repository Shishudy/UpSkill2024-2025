using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreLibrary.DbModels;
using StoreLibrary.EfCoreMethods;
using System.Threading.Tasks;

namespace StoreAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly PurchaseMethods _purchaseMethods;

        public CartController(PurchaseMethods purchaseMethods)
        {
            _purchaseMethods = purchaseMethods;
        }

        // GET: api/cart/{fk_user}/items
        [HttpGet("{fk_user}/items")]
        public async Task<IActionResult> GetCartItemsByUserID(string fk_user)
        {
            List<PurchaseProduct> items = await _purchaseMethods.GetCartItemsByUserIDAsync(fk_user);
            if (items == null || !items.Any())
                return NotFound("No items found in the cart for the specified user.");
            return Ok(items);
        }

        // POST: api/cart/{fk_user}/items
        [HttpPost("{fk_user}/items")]
        public async Task<IActionResult> AddItemToCart(string fk_user, [FromBody] CartItemDto cartItem)
        {
            if (cartItem == null || cartItem.ProductId <= 0 || cartItem.Quantity <= 0)
                return BadRequest("Invalid cart item data.");

            await _purchaseMethods.AddItemToCartAsync(fk_user, cartItem.ProductId, cartItem.Quantity);
            return NoContent();
        }

        // DELETE: api/cart/{fk_user}/items/{productId}
        [HttpDelete("{fk_user}/items/{productId}")]
        public async Task<IActionResult> RemoveItemFromCart(string fk_user, int productId)
        {
            await _purchaseMethods.RemoveItemFromCartAsync(fk_user, productId);
            return NoContent();
        }
    }

    // DTO for adding items to the cart
    public class CartItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}