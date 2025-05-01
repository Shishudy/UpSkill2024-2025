using System;
using System.Collections.Generic;

namespace StoreLibrary.DbModels;

public partial class UserImage
{
    public int FkImage { get; set; }

    public string FkUser { get; set; } = null!;
}
