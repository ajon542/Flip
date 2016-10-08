using System.Collections.Generic;
using System.Linq;

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
    /// The list of indices for cards to pick.
    /// </summary>
    private List<int> shuffledCardIndices;

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
        shuffledCardIndices = Enumerable.Range(0, masterDeck.Count).ToList();

        ResetDeck();
    }

    /// <summary>
    /// Shuffle the deck of cards.
    /// </summary>
    public void ShuffleDeck()
    {
        shuffler.ShuffleDeck(realWorldDeck, shuffledCardIndices);
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
            shuffledCardIndices,
            numberOfCards);

        return cards;
    }

    /// <summary>
    /// Reset the deck of cards to the original state.
    /// </summary>
    public void ResetDeck()
    {
        // Sort the deck.
        shuffledCardIndices = Enumerable.Range(0, masterDeck.Count).ToList();

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
    /// <param name="cardModel">The card to make magic.</param>
    public void MakeMagicCard(CardModel cardModel)
    {
        // Find this card in the deck.
        CardModel card = realWorldDeck.Find(c => c.Equals(cardModel));

        // Make it MAGIC!
        if (card != null)
        {
            card.IsMagic = true;
        }
    }
}
