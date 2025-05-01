using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreLibrary.DbModels;
using StoreLibrary.EfCoreMethods;
using System.Threading.Tasks;

namespace StoreAPI.Controllers.InvoiceControllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly PurchaseMethods _purchaseMethods;

        public CardController(PurchaseMethods purchaseMethods)
        {
            _purchaseMethods = purchaseMethods;
        }

        // GET: api/cards/{fk_user}
        [HttpGet("{fk_user}")]
        public async Task<IActionResult> GetCardsByUserID(string fk_user)
        {
            var cards = await _purchaseMethods.GetCardsByUserIDAsync(fk_user);
            if (cards == null || !cards.Any())
                return NotFound("No cards found for the specified user.");
            return Ok(cards);
        }

        // POST: api/cards/{fk_user}
        [HttpPost("{fk_user}")]
        public async Task<IActionResult> AddCardToPurchase(string fk_user, [FromBody] Card card)
        {
            if (card == null)
                return BadRequest("Card data is required.");

            await _purchaseMethods.AddCardToPurchaseAsync(fk_user, card);
            return CreatedAtAction(nameof(GetCardsByUserID), new { fk_user }, card);
        }

        // DELETE: api/cards/{cardId}
        [HttpDelete("{cardId}")]
        public async Task<IActionResult> DeleteCardById(int cardId)
        {
            await _purchaseMethods.DeleteCardByIdAsync(cardId);
            return NoContent();
        }
    }
}