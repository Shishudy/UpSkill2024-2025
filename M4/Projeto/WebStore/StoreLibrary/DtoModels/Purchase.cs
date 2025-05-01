using System;
using System.Collections.Generic;
using StoreLibrary.DbModels;

namespace StoreLibrary.DbModels;
public partial class DTOPurchase
{
    public int PkPurchase { get; set; }
    public string FkUser { get; set; } = null!;
    public DateOnly? DatePurchase { get; set; }
    public string Status { get; set; } = null!;
}

public partial class Purchase // Ensure this matches the correct class in StoreLibrary.DbModels
{
    public Purchase() { }

    // Copy constructor
    public Purchase(Purchase purchase)
    {
        PkPurchase = purchase.PkPurchase;
        FkUser = purchase.FkUser;
        DatePurchase = purchase.DatePurchase;
        Status = purchase.Status;
    }

    // Method to assign values from another Purchase object
    public void AssignFrom(Purchase purchase)
    {
        this.PkPurchase = purchase.PkPurchase;
        this.FkUser = purchase.FkUser;
        this.DatePurchase = purchase.DatePurchase;
        this.Status = purchase.Status;
    } // Use: purchase.AssignFrom(otherPurchase);

    // Explicit conversion from DTOPurchase to Purchase
    public static explicit operator Purchase(DTOPurchase dto)
    {
        return new Purchase
        {
            PkPurchase = dto.PkPurchase,
            FkUser = dto.FkUser,
            DatePurchase = dto.DatePurchase,
            Status = dto.Status
        };
    } // Use: Purchase purchase = (Purchase)dtoPurchase;

    // Explicit conversion from Purchase to DTOPurchase
    public static explicit operator DTOPurchase(Purchase purchase)
    {
        return new DTOPurchase
        {
            PkPurchase = purchase.PkPurchase,
            FkUser = purchase.FkUser,
            DatePurchase = purchase.DatePurchase,
            Status = purchase.Status
        };
    } //Use: DTOPurchase dtoPurchase = (DTOPurchase)purchase;
}

// Static class for extension methods
public static class PurchaseExtensions
{
    // Convert Purchase to DTOPurchase
    public static DTOPurchase ToDTO(this Purchase purchase)
    {
        return new DTOPurchase
        {
            PkPurchase = purchase.PkPurchase,
            FkUser = purchase.FkUser,
            DatePurchase = purchase.DatePurchase,
            Status = purchase.Status
        };
    }

    // Convert DTOPurchase to Purchase
    public static Purchase ToModel(this DTOPurchase dtoPurchase)
    {
        return new Purchase
        {
            PkPurchase = dtoPurchase.PkPurchase,
            FkUser = dtoPurchase.FkUser,
            DatePurchase = dtoPurchase.DatePurchase,
            Status = dtoPurchase.Status
        };
    }

    // Convert a list of Purchases to a list of DTOPurchases
    public static List<DTOPurchase> ToDTOList(this IEnumerable<Purchase> purchases)
    {
        return purchases.Select(purchase => purchase.ToDTO()).ToList();
    }

    // Convert a list of DTOPurchases to a list of Purchases
    public static List<Purchase> ToModelList(this IEnumerable<DTOPurchase> dtoPurchases)
    {
        return dtoPurchases.Select(dtoPurchase => dtoPurchase.ToModel()).ToList();
    }
}

