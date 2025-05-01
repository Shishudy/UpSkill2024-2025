using System;
using System.Collections.Generic;

namespace StoreLibrary.DbModels;

public partial class Product
{
    public int PkProduct { get; set; }

    public int FkImage { get; set; }

    public string Ean { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double Price { get; set; }

    public int Stock { get; set; }

    public bool Toggle { get; set; }

    public virtual ICollection<CampaignProduct> CampaignProducts { get; set; } = new List<CampaignProduct>();

    public virtual ICollection<PurchaseProduct> PurchaseProducts { get; set; } = new List<PurchaseProduct>();

    public virtual ICollection<Category> FkCategories { get; set; } = new List<Category>();

    public virtual ICollection<Image> FkImages { get; set; } = new List<Image>();
}
