using System;
using System.Collections.Generic;

namespace StoreLibrary.DbModels;

public partial class Invoice
{
    public int PkInvoice { get; set; }

    public int FkAddressInvoice { get; set; }

    public string Name { get; set; } = null!;

    public int Nif { get; set; }

    public DateOnly DateInvoice { get; set; }

    public string? PaypallConfirmation { get; set; }

    public double? Amount { get; set; }

    public virtual Address FkAddressInvoiceNavigation { get; set; } = null!;

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
