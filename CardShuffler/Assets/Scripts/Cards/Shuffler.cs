using System;
using System.Collections.Generic;
using System.Linq;

public class Shuffler : IShuffler
{
    /// <summary>
    /// Shuffle the deck.
    /// </summary>
    /// <param name="currentDeck">The deck.</param>
    /// <param name="indices">The resulting shuffled indices.</param>
    public void ShuffleDeck(List<CardModel> deck, List<int> indices)
    {
        Random rand = new Random();

        indices = Enumerable.Range(0, deck.Count).ToList();

        for (int i = 0; i < deck.Count; ++i)
        {
            int j = rand.Next(0, i);
            Swap(indices, i, j);
        }
    }

    /// <summary>
    /// Swap two indices in a list.
    /// </summary>
    private void Swap(List<int> indices, int i, int j)
    {
        int temp = indices[i];
        indices[i] = indices[j];
        indices[j] = temp;
    }
}
