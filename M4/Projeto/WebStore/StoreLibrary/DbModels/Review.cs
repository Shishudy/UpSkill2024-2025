using System;
using System.Collections.Generic;

namespace StoreLibrary.DbModels;

public partial class Review
{
    public int PkReview { get; set; }

    public DateOnly DataReview { get; set; }

    public int Stars { get; set; }

    public string Comment { get; set; } = null!;

    public bool Toggle { get; set; }

    public virtual ICollection<PurchaseProduct> PurchaseProducts { get; set; } = new List<PurchaseProduct>();

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual ICollection<Image> FkImages { get; set; } = new List<Image>();
}
