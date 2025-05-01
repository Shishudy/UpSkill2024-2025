using System;
using System.Collections.Generic;

namespace StoreLibrary.DbModels;

public partial class CampaignProduct
{
    public int FkCampaign { get; set; }

    public int FkProduct { get; set; }

    public double Discount { get; set; }

    public virtual Campaign FkCampaignNavigation { get; set; } = null!;

    public virtual Product FkProductNavigation { get; set; } = null!;
}
