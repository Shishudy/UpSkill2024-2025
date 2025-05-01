using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreLibrary.DbModels;
using StoreLibrary.EfCoreMethods;
using System.Threading.Tasks;

namespace StoreAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly PurchaseMethods _purchaseMethods;

        public AddressController(PurchaseMethods purchaseMethods)
        {
            _purchaseMethods = purchaseMethods;
        }

        // GET: api/addresses/invoices/{fk_user}
        [HttpGet("invoices/{fk_user}")]
        public async Task<IActionResult> GetInvoiceAddressByUser(string fk_user)
        {
            var addresses = await _purchaseMethods.GetInvoiceAddressByUserAsync(fk_user);
            if (addresses == null || !addresses.Any())
                return NotFound("No addresses found for the specified user's invoices.");
            return Ok(addresses);
        }

        // POST: api/addresses/invoices/{fk_user}
        [HttpPost("invoices/{fk_user}")]
        public async Task<IActionResult> AddAddressToInvoice(string fk_user, [FromBody] Address address)
        {
            if (address == null)
                return BadRequest("Address data is required.");

            await _purchaseMethods.AddAddressToInvoiceAsync(fk_user, address);
            return CreatedAtAction(nameof(GetInvoiceAddressByUser), new { fk_user }, address);
        }

        // DELETE: api/addresses/invoices/{addressId}
        [HttpDelete("{addressId}")]
        public async Task<IActionResult> DeleteAddressById(int addressId)
        {
            await _purchaseMethods.DeleteAddressByIdAsync(addressId);
            return NoContent();
        }
    }
}