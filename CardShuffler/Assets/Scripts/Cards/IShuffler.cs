using System.Collections.Generic;

public interface IShuffler
{
    /// <summary>
    /// Shuffle the deck.
    /// </summary>
    /// <param name="currentDeck">The deck.</param>
    /// <param name="indices">The resulting shuffled indices.</param>
    void ShuffleDeck(List<CardModel> currentDeck, List<int> indices);
}
