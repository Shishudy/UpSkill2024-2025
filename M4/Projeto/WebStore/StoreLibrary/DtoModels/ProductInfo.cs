using System;
using System.Collections.Generic;
using StoreLibrary.DbModels;

namespace StoreLibrary.DbModels
{
    public partial class DTOProductInfo
    {
        public int FkProduct { get; set; }
        public string? Status { get; set; }
        public int Qtt { get; set; }
        public int? FkReview { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public decimal PriceAfterDiscount { get; set; }

        // Default constructor
        public DTOProductInfo() { }

        // Copy constructor
        public DTOProductInfo(DTOProductInfo dtoProductInfo)
        {
            FkProduct = dtoProductInfo.FkProduct;
            Status = dtoProductInfo.Status;
            Qtt = dtoProductInfo.Qtt;
            FkReview = dtoProductInfo.FkReview;
            Price = dtoProductInfo.Price;
            Discount = dtoProductInfo.Discount;
            PriceAfterDiscount = dtoProductInfo.PriceAfterDiscount;
        }

        // Method to assign values from another DTOProductInfo object
        public void AssignFrom(DTOProductInfo dtoProductInfo)
        {
            FkProduct = dtoProductInfo.FkProduct;
            Status = dtoProductInfo.Status;
            Qtt = dtoProductInfo.Qtt;
            FkReview = dtoProductInfo.FkReview;
            Price = dtoProductInfo.Price;
            Discount = dtoProductInfo.Discount;
            PriceAfterDiscount = dtoProductInfo.PriceAfterDiscount;
        }

        // Explicit conversion from PurchaseProduct to DTOProductInfo
        public static explicit operator DTOProductInfo(PurchaseProduct productInfo)
        {
            return new DTOProductInfo
            {
                FkProduct = productInfo.FkProduct,
                Status = productInfo.Status,
                Qtt = productInfo.Qtt,
                FkReview = productInfo.FkReview,
                Price = productInfo.Price,
            };
        } // Use: DTOProductInfo dtoProductInfo = (DTOProductInfo)purchaseProduct;

        // Explicit conversion from DTOProductInfo to PurchaseProduct
        public static explicit operator PurchaseProduct(DTOProductInfo dtoProductInfo)
        {
            return new PurchaseProduct
            {
                FkProduct = dtoProductInfo.FkProduct,
                Status = dtoProductInfo.Status,
                Qtt = dtoProductInfo.Qtt,
                FkReview = dtoProductInfo.FkReview,
                Price = dtoProductInfo.Price,
            };
        }
    }
}