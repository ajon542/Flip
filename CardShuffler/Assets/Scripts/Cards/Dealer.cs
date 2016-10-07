using System.Collections.Generic;

/// <summary>
/// Implementation of the IDealer interface.
/// </summary>
public class Dealer : IDealer
{
    public List<CardModel> DealCards(List<CardModel> deck, List<int> shuffledIndices, int numberOfCards)
    {
        SoftwareAssert.Confirm(numberOfCards <= deck.Count, "Not enough cards in the deck");

        // Convert the dealt card indices to actual CardModels.
        List<CardModel> dealtCards = new List<CardModel>();

        foreach (int cardIndex in shuffledIndices)
        {
            // Dealt the number of cards requested, stop dealing.
            if (numberOfCards == 0)
            {
                break;
            }

            // Obtain the specified card.
            CardModel cardModel = deck[cardIndex];

            // Move that card to dealt cards pile.
            dealtCards.Add(cardModel);

            numberOfCards--;
        }

        return dealtCards;
    }
}
