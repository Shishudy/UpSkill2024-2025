using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreLibrary.DbModels;
using StoreLibrary.EfCoreMethods;
using System.Threading.Tasks;

namespace StoreAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ShipmentAddressController : ControllerBase
    {
        private readonly PurchaseMethods _purchaseMethods;

        public ShipmentAddressController(PurchaseMethods purchaseMethods)
        {
            _purchaseMethods = purchaseMethods;
        }

        // GET: api/shipment-addresses/{fk_user}
        [HttpGet("{fk_user}")]
        public async Task<IActionResult> GetAddressesByUserID(string fk_user)
        {
            var addresses = await _purchaseMethods.GetAddressesByUserIDAsync(fk_user);
            if (addresses == null || !addresses.Any())
                return NotFound("No shipment addresses found for the specified user.");
            return Ok(addresses);
        }

        // POST: api/shipment-addresses/{fk_user}
        [HttpPost("{fk_user}")]
        public async Task<IActionResult> AddAddressToPurchase(string fk_user, [FromBody] Address address)
        {
            if (address == null)
                return BadRequest("Address data is required.");

            await _purchaseMethods.AddAddressToPurchaseAsync(fk_user, address);
            return CreatedAtAction(nameof(GetAddressesByUserID), new { fk_user }, address);
        }
    }
}