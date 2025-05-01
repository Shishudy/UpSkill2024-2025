using System;
using System.Collections.Generic;

namespace StoreLibrary.DbModels;

public partial class Address
{
    public int PkAddress { get; set; }

    public string? FkUser { get; set; }

    public string Country { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FullAddress { get; set; } = null!;

    public string? Name { get; set; }

    public bool? Toggle { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
