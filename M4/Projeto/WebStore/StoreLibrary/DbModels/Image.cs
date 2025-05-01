using System;
using System.Collections.Generic;

namespace StoreLibrary.DbModels;

public partial class Image
{
    public int PkImage { get; set; }

    public string PathImg { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<Campaign> FkCampaigns { get; set; } = new List<Campaign>();

    public virtual ICollection<Product> FkProducts { get; set; } = new List<Product>();

    public virtual ICollection<Review> FkReviews { get; set; } = new List<Review>();
}
