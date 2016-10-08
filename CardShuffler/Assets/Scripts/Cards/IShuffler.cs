using System.Collections.Generic;

public interface IShuffler
{
    /// <summary>
    /// Shuffle the deck.
    /// </summary>
    /// <param name="currentDeck">The deck.</param>
    void ShuffleDeck(List<CardModel> currentDeck);
}
