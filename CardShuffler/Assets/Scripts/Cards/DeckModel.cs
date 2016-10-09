using System;
using System.Collections.Generic;

public class DeckModel
{
    /// <summary>
    /// The master deck. Contains the card in the deck in the original order.
    /// </summary>
    private List<CardModel> masterDeck;

    /// <summary>
    /// Copy of the master deck that can be shuffled. It represents the actual deck state
    /// during dealing etc.
    /// </summary>
    private List<CardModel> realWorldDeck;

    /// <summary>
    /// Reference to the dealer.
    /// </summary>
    private IDealer dealer;

    /// <summary>
    /// Reference to the shuffler.
    /// </summary>
    private IShuffler shuffler;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeckModel"/> class.
    /// </summary>
    /// <param name="dealer">The dealer implementation.</param>
    /// <param name="shuffler">The shuffler implementation.</param>
    /// <param name="cards">The cards in the deck.</param>
    public DeckModel(
        IDealer dealer,
        IShuffler shuffler,
        List<CardModel> cards)
    {
        SoftwareAssert.Confirm(dealer != null, "The dealer cannot be null");
        SoftwareAssert.Confirm(shuffler != null, "The shuffler cannot be null");
        SoftwareAssert.Confirm(cards != null, "The cards cannot be null");

        this.dealer = dealer;
        this.shuffler = shuffler;
        masterDeck = cards;

        ResetDeck();
    }

    /// <summary>
    /// Whether the deck has any cards left.
    /// </summary>
    public bool IsEmpty()
    {
        return realWorldDeck.Count == 0;
    }

    /// <summary>
    /// Shuffle the deck of cards.
    /// </summary>
    public void ShuffleDeck()
    {
        // Shuffle the copy of the deck.
        shuffler.ShuffleDeck(realWorldDeck);
    }

    /// <summary>
    /// Get cards from the top of the deck.
    /// </summary>
    /// <param name="numberOfCards">The number of cards to get.</param>
    /// <returns>The top cards from the deck.</returns>
    public List<CardModel> DealCards(int numberOfCards)
    {
        List<CardModel> cards = dealer.DealCards(
            realWorldDeck,
            numberOfCards);

        return cards;
    }

    /// <summary>
    /// Reset the deck of cards to the original state.
    /// </summary>
    public void ResetDeck()
    {
        // Make a deep copy of the master deck.
        realWorldDeck = new List<CardModel>();
        foreach (CardModel card in masterDeck)
        {
            realWorldDeck.Add(new CardModel(card));
        }
    }

    /// <summary>
    /// Set magic card in the deck.
    /// </summary>
    /// <param name="number">The number of cards to make magic.</param>
    public void MakeMagicCards(int number)
    {
        realWorldDeck[0].IsMagic = true;

        Random rand = new Random();

        while (number > 0)
        {
            int cardIndex = rand.Next(0, realWorldDeck.Count);

            if (!realWorldDeck[cardIndex].IsMagic)
            {
                realWorldDeck[cardIndex].IsMagic = true;
                number--;
            }
        }
    }

    /// <summary>
    /// Peek at the bottom card of the deck.
    /// </summary>
    /// <returns>The bottom card of the deck.</returns>
    public CardModel Peek()
    {
        if (realWorldDeck.Count > 0)
        {
            return realWorldDeck[realWorldDeck.Count - 1];
        }

        return null;
    }
}
