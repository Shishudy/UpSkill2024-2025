using System;
using System.Collections.Generic;

namespace StoreLibrary.DbModels;

public partial class PurchaseProduct
{
    public int FkPurchase { get; set; }

    public int FkProduct { get; set; }

    public string? Status { get; set; }

    public int Qtt { get; set; }

    public int? FkReview { get; set; }

    public double Price { get; set; }

    public virtual Product FkProductNavigation { get; set; } = null!;

    public virtual Purchase FkPurchaseNavigation { get; set; } = null!;

    public virtual Review? FkReviewNavigation { get; set; }
}
