using System;
using System.Collections.Generic;

namespace StoreLibrary.DbModels;

public partial class Favourite
{
    public int FkProduct { get; set; }

    public string FkUser { get; set; } = null!;
}
