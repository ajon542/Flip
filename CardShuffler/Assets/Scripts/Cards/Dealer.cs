using System.Collections.Generic;

/// <summary>
/// Implementation of the IDealer interface.
/// </summary>
public class Dealer : IDealer
{
    public List<CardModel> DealCards(List<CardModel> deck, int numberOfCards)
    {
        SoftwareAssert.Confirm(numberOfCards <= deck.Count, "Not enough cards in the deck");

        // Convert the dealt card indices to actual CardModels.
        List<CardModel> dealtCards = new List<CardModel>();

        //// TODO: Probably could use a stack instead of a list.
        while (numberOfCards > 0)
        {
            // Get the card from top of deck.
            CardModel cardModel = deck[0];

            // Move that card to dealt cards pile.
            dealtCards.Add(cardModel);

            // Remove the card from deck.
            deck.RemoveAt(0);

            numberOfCards--;
        }

        return dealtCards;
    }
}
