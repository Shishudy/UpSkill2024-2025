//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using StoreLibrary.DbModels;
//using StoreLibrary.EfCoreMethods;

//namespace StoreAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PurchaseController : ControllerBase
//    {
//        private readonly PurchaseMethods _purchaseMethods;

//        public PurchaseController(PurchaseMethods purchaseMethods)
//        {
//            _purchaseMethods = purchaseMethods;
//        } 
        
//        // -------------------------------
//        // Purchase Management
//        // -------------------------------

//        [HttpGet("api/purchases")]
//        public IActionResult GetAllPurchases()
//        {
//            var purchases = _purchaseMethods.GetAllPurchases();
//            return Ok(purchases);
//        }

//        // [HttpGet("api/purchases/{id}")]
//        // public IActionResult GetPurchaseById(int id)
//        // {
//        //     var purchase = _purchaseMethods.GetPurchaseById(id);
//        //     if (purchase == null) return NotFound();
//        //     return Ok(purchase);
//        // }
        
//        // [HttpPost("api/purchases")]
//        // public IActionResult AddPurchase([FromBody] Purchase purchase)
//        // {
//        //     _purchaseMethods.AddPurchase(purchase);
//        //     return CreatedAtAction(nameof(GetPurchaseById), new { id = purchase.PkPurchase }, purchase);
//        // }
        
//        [HttpPut("api/purchases/{id}")]
//        public IActionResult UpdatePurchase(int id, [FromBody] Purchase purchase)
//        {
//            if (id != purchase.PkPurchase) return BadRequest("ID mismatch");
//            _purchaseMethods.UpdatePurchase(purchase);
//            return NoContent();
//        }
        
//        [HttpDelete("api/purchases/{id}")]
//        public IActionResult DeletePurchase(int id)
//        {
//            _purchaseMethods.DeletePurchase(id);
//            return NoContent();
//        }
        
//        [HttpGet("api/cart/{fk_user}")]
//        public IActionResult GetCartByUserID(string fk_user)
//        {
//            var cart = _purchaseMethods.GetCartByUserID(fk_user);
//            return Ok(cart);
//        }
        
////

//        [HttpGet("api/cart/{fk_user}/items")]
//        public IActionResult GetCartItemsByUserID(string fk_user)
//        {
//            var items = _purchaseMethods.GetCartItemsByUserID(fk_user);
//            return Ok(items);
//        }
        
//        [HttpPost("api/cart/{fk_user}/items")]
//        public IActionResult AddItemToCart(string fk_user, [FromBody] PurchaseProduct item)
//        {
//            _purchaseMethods.AddItemToCart(fk_user, item.FkProduct, item.Qtt);
//            return NoContent();
//        }
        
//        [HttpDelete("api/cart/{fk_user}/items/{productId}")]
//        public IActionResult RemoveItemFromCart(string fk_user, int productId)
//        {
//            _purchaseMethods.RemoveItemFromCart(fk_user, productId);
//            return NoContent();
//        }

//        [HttpGet("api/cards/{fk_user}")]
//        public IActionResult GetCardsByUserID(string fk_user)
//        {
//            var cards = _purchaseMethods.GetCardsByUserID(fk_user);
//            return Ok(cards);
//        }
        
//        [HttpPost("api/cards/{fk_user}")]
//        public IActionResult AddCardToPurchase(string fk_user, [FromBody] Card card)
//        {
//            _purchaseMethods.AddCardToPurchase(fk_user, card);
//            return NoContent();
//        }
        
//        [HttpDelete("api/cards/{cardId}")]
//        public IActionResult DeleteCardById(int cardId)
//        {
//            _purchaseMethods.DeleteCardById(cardId);
//            return NoContent();
//        }
        
//        [HttpGet("api/invoices/{fk_user}")]
//        public IActionResult GetInvoicesByUserID(string fk_user)
//        {
//            var invoices = _purchaseMethods.GetInvoicesByUserID(fk_user);
//            return Ok(invoices);
//        }
        
//        [HttpGet("api/invoices/id/{id}")]
//        public IActionResult GetInvoiceById(int id)
//        {
//            var invoice = _purchaseMethods.GetInvoiceById(id);
//            if (invoice == null) return NotFound();
//            return Ok(invoice);
//        }
        
//        [HttpPost("api/invoices/{fk_user}")]
//        public IActionResult AddInvoiceToPurchase(string fk_user, [FromBody] Invoice invoice)
//        {
//            _purchaseMethods.AddInvoiceToPurchase(fk_user, invoice);
//            return NoContent();
//        }
        
//        [HttpDelete("api/invoices/{fk_user}")]
//        public IActionResult DeleteInvoice(string fk_user)
//        {
//            _purchaseMethods.DeleteInvoice(fk_user);
//            return NoContent();
//        }

//        [HttpGet("api/addresses/{fk_user}")]
//        public IActionResult GetAddressesByUserID(string fk_user)
//        {
//            var addresses = _purchaseMethods.GetAddressesByUserID(fk_user);
//            return Ok(addresses);
//        }
        

        
//        [HttpPost("api/addresses/{fk_user}")]
//        public IActionResult AddAddressToPurchase(string fk_user, [FromBody] Address address)
//        {
//            _purchaseMethods.AddAddressToPurchase(fk_user, address);
//            return NoContent();
//        }
        

        
//        [HttpGet("api/addresses/invoices/{fk_user}")]
//        public IActionResult GetInvoiceAddressByUser(string fk_user)
//        {
//            var addresses = _purchaseMethods.GetInvoiceAddressByUser(fk_user);
//            return Ok(addresses);
//        }
        

        
//        [HttpPost("api/addresses/invoices/{fk_user}")]
//        public IActionResult AddAddressToInvoice(string fk_user, [FromBody] Address address)
//        {
//            _purchaseMethods.AddAddressToInvoice(fk_user, address);
//            return NoContent();
//        }
        

        
//        [HttpDelete("api/addresses/{addressId}")]
//        public IActionResult DeleteAddressById(int addressId)
//        {
//            _purchaseMethods.DeleteAddressById(addressId);
//            return NoContent();
//        }
        

//    }


//}
