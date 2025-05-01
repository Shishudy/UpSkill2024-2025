using Microsoft.AspNetCore.Mvc;
using StoreLibrary.DbModels;
using StoreLibrary.EfCoreMethods;
using System.Threading.Tasks;

namespace StoreAPI.Controllers.InvoiceControllers
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

        // GET: api/cart/{fk_user}
        [HttpGet("{fk_user}")]
        public async Task<IActionResult> GetCartByUserID(string fk_user)
        {
            var cart = await _purchaseMethods.GetCartByUserIDAsync(fk_user); // Direct await
            if (cart == null)
                return NotFound("Cart not found for the specified user.");
            return Ok(cart);
        }

        // DELETE: api/cart/{fk_user}
        [HttpDelete("{fk_user}")]
        public async Task<IActionResult> DeletePurchase(string fk_user)
        {
            await _purchaseMethods.DeletePurchaseAsync(fk_user); // Direct await
            return NoContent();
        }
    }
}