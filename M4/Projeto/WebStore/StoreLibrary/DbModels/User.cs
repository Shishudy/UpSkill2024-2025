using System;
using System.Collections.Generic;

namespace StoreLibrary.DbModels;

public partial class User
{
    public int PkUser { get; set; }

    public string? FkUser { get; set; }
}
