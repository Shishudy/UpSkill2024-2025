using StoreLibrary.DbModels;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace StoreLibrary.EfCoreMethods
{
    public class PurchaseMethods
    {
        private readonly StoreDbContext _context;

        public PurchaseMethods(StoreDbContext context)
        {
            _context = context;
        }

        // -------------------------------
        // CRUD Operations for Purchases
        // -------------------------------
        public async Task<List<Purchase>> GetAllPurchasesAsync()
        {
            return await _context.Purchases.ToListAsync();
        }

        public async Task AddPurchaseAsync(Purchase purchase)
        {
            await _context.Purchases.AddAsync(purchase);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePurchaseAsync(Purchase purchase)
        {
            _context.Purchases.Update(purchase);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePurchaseAsync(int id)
        {
            var purchase = await _context.Purchases.FirstOrDefaultAsync(p => p.PkPurchase == id);
            if (purchase != null)
            {
                _context.Purchases.Remove(purchase);
                await _context.SaveChangesAsync();
            }
        }

        // -------------------------------
        // Purchase Management
        // -------------------------------
        public async Task<Purchase> GetCartByUserIDAsync(string fk_user)
        {
            var cart = await _context.Purchases.FirstOrDefaultAsync(p => p.FkUser == fk_user && p.Status == "Cart");
            if (cart == null)
            {
                var new_purchase = new Purchase
                {
                    FkUser = fk_user,
                    Status = "Cart",
                };
                await AddPurchaseAsync(new_purchase); // SaveChanges updates new_purchase
                return new_purchase;
            }
            return cart;
        }

        public async Task DeletePurchaseAsync(string fk_user)
        {
            var cart = await GetCartByUserIDAsync(fk_user);
            if (cart != null)
            {
                await DeleteAddressByIdAsync(cart.FkAddressShipment);
                await DeleteCardByIdAsync(cart.FkCard);
                await DeleteInvoiceAsync(cart.FkUser);
                _context.PurchaseProducts.RemoveRange(
                    _context.PurchaseProducts.Where(p => p.FkPurchase == cart.PkPurchase));
                _context.Purchases.Remove(cart);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Cart not found");
            }
        }

        // -------------------------------
        // Cart Management
        // -------------------------------
        public async Task<List<PurchaseProduct>> GetCartItemsByUserIDAsync(string fk_user)
        {
            var cart = await GetCartByUserIDAsync(fk_user);
            return await _context.PurchaseProducts
                .Where(p => p.FkPurchase == cart.PkPurchase)
                .ToListAsync();
        }

        public async Task AddItemToCartAsync(string fk_user, int productId, int quantity)
        {
            var cart = await GetCartByUserIDAsync(fk_user);

            var existingItem = await _context.PurchaseProducts
                .FirstOrDefaultAsync(pp => pp.FkPurchase == cart.PkPurchase && pp.FkProduct == productId);

            if (existingItem == null)
            {
                var newItem = new PurchaseProduct
                {
                    FkPurchase = cart.PkPurchase,
                    FkProduct = productId,
                    Qtt = quantity
                };
                await _context.PurchaseProducts.AddAsync(newItem);
            }
            else
            {
                existingItem.Qtt += quantity;
                if (existingItem.Qtt < 1)
                    _context.PurchaseProducts.Remove(existingItem);
                else
                    _context.PurchaseProducts.Update(existingItem);
            }
            await _context.SaveChangesAsync();
        }


        public async Task RemoveItemFromCartAsync(string fk_user, int productId)
        {
            var cart = await GetCartByUserIDAsync(fk_user);

            var itemToRemove = await _context.PurchaseProducts
                .FirstOrDefaultAsync(pp => pp.FkPurchase == cart.PkPurchase && pp.FkProduct == productId);

            if (itemToRemove != null)
            {
                _context.PurchaseProducts.Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
        }

        // -------------------------------
        // Card Management
        // -------------------------------
        public async Task<List<Card>> GetCardsByUserIDAsync(string fk_user)
        {
            return await _context.Cards
                .Where(c => c.FkUser == fk_user && c.Toogle == true)
                .ToListAsync();
        }

        public async Task AddCardToPurchaseAsync(string fk_user, Card card)
        {
            var cart = await GetCartByUserIDAsync(fk_user);

            var existingCard = await _context.Cards
                .FirstOrDefaultAsync(c => c.PkCard == cart.FkCard);

            card.FkUser = fk_user;

            if (existingCard == null)
            {
                cart.FkCardNavigation = card;
                await _context.Cards.AddAsync(card);
            }
            else
            {
                existingCard.AssignFrom(card); // Copy values from the new card
                _context.Cards.Update(existingCard);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCardByIdAsync(int? cardId)
        {
            if (cardId == null)
                throw new InvalidOperationException("Card ID is null");

            var card = await _context.Cards.FirstOrDefaultAsync(c => c.PkCard == cardId);
            if (card != null)
            {
                card.Toogle = true; // Soft delete
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Card not found");
            }
        }

        // -------------------------------
        // Invoice Management
        // -------------------------------
        public async Task<List<Invoice>> GetInvoicesByUserIDAsync(string fk_user)
        {
            var fkInvoices = _context.Purchases
                .Where(p => p.FkUser == fk_user)
                .Select(p => p.FkInvoice);

            return await _context.Invoices
                .Where(i => fkInvoices.Contains(i.PkInvoice))
                .ToListAsync();
        }

        public async Task<Invoice?> GetInvoiceByIdAsync(int id)
        {
            return await _context.Invoices.FirstOrDefaultAsync(i => i.PkInvoice == id);
        }

        public async Task AddInvoiceToPurchaseAsync(string fk_user, Invoice invoice)
        {
            var cart = await GetCartByUserIDAsync(fk_user);

            cart.Status = "Pending Payment";
            var existingInvoice = await _context.Invoices
                .FirstOrDefaultAsync(i => i.PkInvoice == cart.FkInvoice);

            if (existingInvoice == null)
            {
                cart.FkInvoiceNavigation = invoice;
                await _context.Invoices.AddAsync(invoice);
            }
            else
            {
                existingInvoice.AssignFrom(invoice); // Copy values from the new invoice
                _context.Invoices.Update(existingInvoice);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteInvoiceAsync(string fk_user)
        {
            var cart = await GetCartByUserIDAsync(fk_user);

            var existingInvoice = await _context.Invoices
                .FirstOrDefaultAsync(i => i.PkInvoice == cart.FkInvoice);

            if (existingInvoice != null && cart.Status != "finalized")
            {
                await DeleteAddressByIdAsync(existingInvoice.FkAddressInvoice);
                _context.Invoices.Remove(existingInvoice);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Invoice not found or already finalized");
            }
        }

        // -------------------------------
        // Address Shipment Management
        // -------------------------------

        public async Task<List<Address>> GetAddressesByUserIDAsync(string fk_user)
        {
            return await _context.Addresses
                .Where(a => a.FkUser == fk_user && a.Toggle == true)
                .ToListAsync();
        }

        public async Task AddAddressToPurchaseAsync(string fk_user, Address address)
        {
            var cart = await GetCartByUserIDAsync(fk_user);

            var existingAddress = await _context.Addresses
                .FirstOrDefaultAsync(a => a.PkAddress == cart.FkAddressShipment);

            address.FkUser = fk_user;

            if (existingAddress == null)
            {
                cart.FkAddressShipmentNavigation = address;
                await _context.Addresses.AddAsync(address);
            }
            else
            {
                existingAddress.AssignFrom(address); // Copy values from the new address
                _context.Addresses.Update(existingAddress);
            }

            await _context.SaveChangesAsync();
        }

        // -------------------------------
        // Address Invoice Management
        // -------------------------------

        public async Task<List<Address>> GetInvoiceAddressByUserAsync(string fk_user)
        {
            var invoices = await GetInvoicesByUserIDAsync(fk_user);
            if (invoices == null || !invoices.Any())
                throw new InvalidOperationException("No invoices found for this user");

            var addresses = invoices
                .Where(i => i.FkAddressInvoice != null)
                .Select(i => i.FkAddressInvoiceNavigation)
                .Where(a => a.Toggle == true)
                .ToList();

            return addresses;
        }

        public async Task AddAddressToInvoiceAsync(string fk_user, Address address)
        {
            var cart = await GetCartByUserIDAsync(fk_user);
            var existingInvoice = await _context.Invoices
                .FirstOrDefaultAsync(i => i.PkInvoice == cart.FkInvoice);

            if (existingInvoice == null)
                throw new InvalidOperationException("Invoice not found");

            if (existingInvoice.FkAddressInvoice == null)
            {
                existingInvoice.FkAddressInvoiceNavigation = address;
                await _context.Addresses.AddAsync(address);
            }
            else
            {
                var existingAddress = await _context.Addresses
                    .FirstOrDefaultAsync(a => a.PkAddress == existingInvoice.FkAddressInvoice);

                if (existingAddress != null)
                {
                    existingAddress.AssignFrom(address); // Copy values from the new address
                    _context.Addresses.Update(existingAddress);
                }
                else
                {
                    throw new InvalidOperationException("Address not found");
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAddressByIdAsync(int? addressId)
        {
            if (addressId == null)
                throw new ArgumentNullException(nameof(addressId), "Address ID cannot be null");

            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.PkAddress == addressId);
            if (address != null)
            {
                address.Toggle = true; // Soft delete
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Address not found");
            }
        }

    }
}
 