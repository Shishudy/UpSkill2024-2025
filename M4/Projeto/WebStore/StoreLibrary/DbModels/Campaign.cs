using System;
using System.Collections.Generic;

namespace StoreLibrary.DbModels;

public partial class Campaign
{
    public int PkCampaign { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly DateEnd { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CampaignProduct> CampaignProducts { get; set; } = new List<CampaignProduct>();

    public virtual ICollection<Image> FkImages { get; set; } = new List<Image>();
}
