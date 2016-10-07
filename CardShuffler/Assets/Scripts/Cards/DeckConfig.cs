using System.Collections.Generic;

/// <summary>
/// Class containing the deck configuration.
/// </summary>
public class DeckConfig
{
    /// <summary>
    /// Gets all the <see cref="SuitName"/> in this deck configuration.
    /// </summary>
    public List<SuitName> SuitNames { get; private set; }

    /// <summary>
    /// Gets all the <see cref="RankName"/> in this deck configuration.
    /// </summary>
    public List<RankName> RankNames { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DeckConfig"/> class.
    /// </summary>
    public DeckConfig()
    {
        //// TODO: Configuration would ideally be loaded from file.

        SuitNames = new List<SuitName>
        {
            "Clubs", "Diamonds", "Hearts", "Spades"
        };

        RankNames = new List<RankName>
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace"
        };
    }

    /// <summary>
    /// Gets the initial deck state. This method will pair the suit and rank
    /// together to create the individual cards in the deck.
    /// </summary>
    /// <returns>The list of cards in the deck.</returns>
    public List<CardModel> GetInitialDeckState()
    {
        List<CardModel> cards = new List<CardModel>();

        foreach (RankName rankName in RankNames)
        {
            foreach (SuitName suitName in SuitNames)
            {
                CardModel cardModel = new CardModel(suitName, rankName);
                cards.Add(cardModel);
            }
        }

        return cards;
    }
}
