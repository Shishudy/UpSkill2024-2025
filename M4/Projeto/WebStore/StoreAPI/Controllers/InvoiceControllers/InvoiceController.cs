using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreLibrary.DbModels;
using StoreLibrary.EfCoreMethods;
using System.Threading.Tasks;

namespace StoreAPI.Controllers.InvoiceControllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly PurchaseMethods _purchaseMethods;

        public InvoiceController(PurchaseMethods purchaseMethods)
        {
            _purchaseMethods = purchaseMethods;
        }

        // GET: api/invoices/{fk_user}
        [HttpGet("{fk_user}")]
        public async Task<IActionResult> GetInvoicesByUserID(string fk_user)
        {
            var invoices = await _purchaseMethods.GetInvoicesByUserIDAsync(fk_user);
            if (invoices == null || !invoices.Any())
                return NotFound("No invoices found for the specified user.");
            return Ok(invoices);
        }

        // GET: api/invoices/id/{id}
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            var invoice = await _purchaseMethods.GetInvoiceByIdAsync(id);
            if (invoice == null)
                return NotFound("Invoice not found.");
            return Ok(invoice);
        }

        // POST: api/invoices/{fk_user}
        [HttpPost("{fk_user}")]
        public async Task<IActionResult> AddInvoiceToPurchase(string fk_user, [FromBody] Invoice invoice)
        {
            if (invoice == null)
                return BadRequest("Invoice data is required.");

            await _purchaseMethods.AddInvoiceToPurchaseAsync(fk_user, invoice);
            return CreatedAtAction(nameof(GetInvoicesByUserID), new { fk_user }, invoice);
        }

        // DELETE: api/invoices/{fk_user}
        [HttpDelete("{fk_user}")]
        public async Task<IActionResult> DeleteInvoice(string fk_user)
        {
            await _purchaseMethods.DeleteInvoiceAsync(fk_user);
            return NoContent();
        }
    }
}