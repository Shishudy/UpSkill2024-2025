using System;
using System.Collections.Generic;

namespace StoreLibrary.DbModels
{
    // DTOInvoice class
    public partial class DTOInvoice
    {
        public int PkInvoice { get; set; }
        public string Name { get; set; } = null!;
        public int Nif { get; set; }
        public DateOnly DateInvoice { get; set; }
        public double? Amount { get; set; }
    }

    // Invoice class
    public partial class Invoice
    {
        public Invoice() { }

        // Copy constructor
        public Invoice(Invoice invoice)
        {
            PkInvoice = invoice.PkInvoice;
            FkAddressInvoice = invoice.FkAddressInvoice;
            Name = invoice.Name;
            Nif = invoice.Nif;
            DateInvoice = invoice.DateInvoice;
            PaypallConfirmation = invoice.PaypallConfirmation;
            Amount = invoice.Amount;
            FkAddressInvoiceNavigation = invoice.FkAddressInvoiceNavigation;
            Purchases = invoice.Purchases;
        } // Use: new Invoice(existingInvoice);

        // Method to assign values from another Invoice object
        public void AssignFrom(Invoice invoice)
        {
            PkInvoice = invoice.PkInvoice;
            Name = invoice.Name;
            Nif = invoice.Nif;
            DateInvoice = invoice.DateInvoice;
            PaypallConfirmation = invoice.PaypallConfirmation;
            Amount = invoice.Amount;
        } // Use: existingInvoice.AssignFrom(newInvoice);

        // Explicit conversion from DTOInvoice to Invoice
        public static explicit operator Invoice(DTOInvoice dto)
        {
            return new Invoice
            {
                PkInvoice = dto.PkInvoice,
                Name = dto.Name,
                Nif = dto.Nif,
                DateInvoice = dto.DateInvoice,
                Amount = dto.Amount,
            };
        } // Use: new Invoice(dto);

        // Explicit conversion from Invoice to DTOInvoice
        public static explicit operator DTOInvoice(Invoice invoice)
        {
            return new DTOInvoice
            {
                PkInvoice = invoice.PkInvoice,
                Name = invoice.Name,
                Nif = invoice.Nif,
                DateInvoice = invoice.DateInvoice,
                Amount = invoice.Amount,
            };
        } // Use: new DTOInvoice(invoice);
    }
}