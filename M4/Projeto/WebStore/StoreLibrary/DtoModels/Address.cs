using System;
using System.Collections.Generic;
namespace StoreLibrary.DbModels
{
    // DTOAddress class
    public partial class DTOAddress
    {
        public int PkAddress { get; set; }
        public string? FkUser { get; set; }
        public string Country { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FullAddress { get; set; } = null!;
        public string? Name { get; set; }
        public bool? Toggle { get; set; }
    }

    // Address class
    public partial class Address
    {
        public Address() { }

        // Copy constructor
        public Address(Address address)
        {
            PkAddress = address.PkAddress;
            FkUser = address.FkUser;
            Country = address.Country;
            Phone = address.Phone;
            Email = address.Email;
            FullAddress = address.FullAddress;
            Name = address.Name;
            Toggle = address.Toggle;
        }

        // Method to assign values from another Address object
        public void AssignFrom(Address address)
        {
            PkAddress = address.PkAddress;
            FkUser = address.FkUser;
            Country = address.Country;
            Phone = address.Phone;
            Email = address.Email;
            FullAddress = address.FullAddress;
            Name = address.Name;
            Toggle = address.Toggle;
        }

        // Explicit conversion from DTOAddress to Address
        public static explicit operator Address(DTOAddress dto)
        {
            return new Address
            {
                PkAddress = dto.PkAddress,
                FkUser = dto.FkUser,
                Country = dto.Country,
                Phone = dto.Phone,
                Email = dto.Email,
                FullAddress = dto.FullAddress,
                Name = dto.Name,
                Toggle = dto.Toggle
            };
        }

        // Explicit conversion from Address to DTOAddress
        public static explicit operator DTOAddress(Address address)
        {
            return new DTOAddress
            {
                PkAddress = address.PkAddress,
                FkUser = address.FkUser,
                Country = address.Country,
                Phone = address.Phone,
                Email = address.Email,
                FullAddress = address.FullAddress,
                Name = address.Name,
                Toggle = address.Toggle
            };
        } //use: DTOAddress dtoAddress = (DTOAddress)address;
    }
}