using System;
using System.Collections.Generic;
using StoreLibrary.DbModels;

namespace StoreLibrary.DbModels
{
    // DTOCard class
    public partial class DTOCard
    {
    public int PkCard { get; set; }

    public string FkUser { get; set; } = null!;

    public long? Number { get; set; }

    public DateOnly? Expiration { get; set; }

    public int? Code { get; set; }

    public string? Name { get; set; }

    public bool? Toogle { get; set; }

    }

    // Card class
    public partial class Card
    {

        public Card() { }

        // Copy constructor
        public Card(Card card)
        {
            Number = card.Number;
            Expiration = card.Expiration;
            Code = card.Code;
            Name = card.Name;
            Toogle = card.Toogle;
        } // Use: new Card(existingCard);

        // Method to assign values from another Card object
        public void AssignFrom(Card card)
        {
            this.Number = card.Number;
            this.Expiration = card.Expiration;
            this.Code = card.Code;
            this.Name = card.Name;
            this.Toogle = card.Toogle;
        } // Use: existingCard.AssignFrom(newCard);

        // Explicit conversion from DTOCard to Card
        public static explicit operator Card(DTOCard dto)
        {
            return new Card
            {
                Number = dto.Number,
                Expiration = dto.Expiration,
                Code = dto.Code,
                Name = dto.Name,
                Toogle = dto.Toogle
            };
        } // Use: Card card = (Card)dtoCard;

        // Explicit conversion from Card to DTOCard
        public static explicit operator DTOCard(Card card)
        {
            return new DTOCard
            {
                Number = card.Number,
                Expiration = card.Expiration,
                Code = card.Code,
                Name = card.Name,
                Toogle = card.Toogle
            };
        } // Use: DTOCard dtoCard = (DTOCard)card;
    }

    // Static class for extension methods
    public static class CardExtensions
    {
        // Convert Card to DTOCard
        public static DTOCard ToDTO(this Card card)
        {
            return new DTOCard
            {
                Number = card.Number,
                Expiration = card.Expiration,
                Code = card.Code,
                Name = card.Name,
                Toogle = card.Toogle
            };
        } // Use: DTOCard dtoCard = card.ToDTO();

        // Convert DTOCard to Card
        public static Card ToModel(this DTOCard dtoCard)
        {
            return new Card
            {
                Number = dtoCard.Number,
                Expiration = dtoCard.Expiration,
                Code = dtoCard.Code,
                Name = dtoCard.Name,
                Toogle = dtoCard.Toogle
            };
        } // Use: Card card = dtoCard.ToModel();

        // Convert a list of Cards to a list of DTOCards
        public static List<DTOCard> ToDTOList(this IEnumerable<Card> cards)
        {
            return cards.Select(card => card.ToDTO()).ToList();
        } // Use: List<DTOCard> dtoCards = cards.ToDTOList();

        // Convert a list of DTOCards to a list of Cards
        public static List<Card> ToModelList(this IEnumerable<DTOCard> dtoCards)
        {
            return dtoCards.Select(dtoCard => dtoCard.ToModel()).ToList();
        } // Use: List<Card> cards = dtoCards.ToModelList();
    }
}