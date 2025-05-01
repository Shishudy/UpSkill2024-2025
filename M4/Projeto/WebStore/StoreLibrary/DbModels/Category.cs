using System;
using System.Collections.Generic;

namespace StoreLibrary.DbModels;

public partial class Category
{
    public int PkCategory { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> FkProducts { get; set; } = new List<Product>();
}
