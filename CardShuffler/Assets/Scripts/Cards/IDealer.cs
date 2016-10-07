using System.Collections.Generic;

public interface IDealer
{
    /// <summary>
    /// Deal a number of cards from a deck.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The shuffled indices specifies the index of the next card in the deck to deal.
    /// For example, if the next value in the shuffled indicies list is 5, the card at
    /// index 5 in the deck will be the next card dealt.
    /// </para>
    /// </remarks>
    /// <param name="deck">The deck of cards from which to deal.</param>
    /// <param name="shuffledIndices">The indices of cards to deal.</param>
    /// <param name="numberOfCards">The number of cards to deal.</param>
    /// <returns>The list of dealt cards.</returns>
    List<CardModel> DealCards(List<CardModel> deck, List<int> shuffledIndices, int numberOfCards);
}