using System.Collections.Generic;

public interface IDealer
{
    /// <summary>
    /// Deal a number of cards from a deck.
    /// </summary>
    /// <param name="deck">The deck of cards from which to deal.</param>
    /// <param name="numberOfCards">The number of cards to deal.</param>
    /// <returns>The list of dealt cards.</returns>
    List<CardModel> DealCards(List<CardModel> deck, int numberOfCards);
}