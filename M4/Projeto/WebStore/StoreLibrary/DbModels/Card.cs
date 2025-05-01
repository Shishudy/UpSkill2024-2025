using System;
using System.Collections.Generic;

namespace StoreLibrary.DbModels;

public partial class Card
{
    public int PkCard { get; set; }

    public string FkUser { get; set; } = null!;

    public long? Number { get; set; }

    public DateOnly? Expiration { get; set; }

    public int? Code { get; set; }

    public string? Name { get; set; }

    public bool? Toogle { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
