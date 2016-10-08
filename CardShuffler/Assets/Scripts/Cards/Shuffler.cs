using System;
using System.Collections.Generic;
using System.Linq;

public class Shuffler : IShuffler
{
    /// <summary>
    /// Shuffle the deck.
    /// </summary>
    /// <param name="currentDeck">The deck.</param>
    public void ShuffleDeck(List<CardModel> deck)
    {
        Random rand = new Random();

        for (int i = 0; i < deck.Count; ++i)
        {
            int j = rand.Next(0, i);
            Swap(deck, i, j);
        }
    }

    /// <summary>
    /// Swap two indices in a list.
    /// </summary>
    private void Swap(List<CardModel> deck, int i, int j)
    {
        CardModel temp = deck[i];
        deck[i] = deck[j];
        deck[j] = temp;
    }
}
