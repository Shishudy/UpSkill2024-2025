using System;
using System.Collections.Generic;

namespace StoreLibrary.DbModels;

public partial class Purchase
{
    public int PkPurchase { get; set; }

    public string FkUser { get; set; } = null!;

    public int? FkInvoice { get; set; }

    public int? FkReview { get; set; }

    public DateOnly? DatePurchase { get; set; }

    public string Status { get; set; } = null!;

    public int? FkAddressShipment { get; set; }

    public int? FkCard { get; set; }

    public virtual Address? FkAddressShipmentNavigation { get; set; }

    public virtual Card? FkCardNavigation { get; set; }

    public virtual Invoice? FkInvoiceNavigation { get; set; }

    public virtual Review? FkReviewNavigation { get; set; }

    public virtual ICollection<PurchaseProduct> PurchaseProducts { get; set; } = new List<PurchaseProduct>();
}
