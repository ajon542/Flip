
/// <summary>
/// Logical model representing a single card.
/// </summary>
public class CardModel
{
    /// <summary>
    /// Gets the string representation of the card suit.
    /// </summary>
    public SuitName SuitName { get; private set; }

    /// <summary>
    /// Gets the string representation of the card rank.
    /// </summary>
    public RankName RankName { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the card is magic.
    /// </summary>
    public bool IsMagic { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CardModel"/> class.
    /// </summary>
    /// <param name="suitName">The suit string.</param>
    /// <param name="rankName">The rank string.</param>
    /// <param name="isMagic">Whether the card is considered MAGIC!</param>
    public CardModel(SuitName suitName, RankName rankName, bool isMagic = false)
    {
        SuitName = suitName;
        RankName = rankName;
        IsMagic = isMagic;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CardModel"/> class from
    /// another CardModel object.
    /// </summary>
    /// <param name="other">The CardModel to copy.</param>
    public CardModel(CardModel other)
    {
        SuitName = other.SuitName;
        RankName = other.RankName;
        IsMagic = other.IsMagic;
    }

    /// <summary>
    /// A string representation of the card.
    /// </summary>
    /// <returns>String representation of the card.</returns>
    public override string ToString()
    {
        string str = string.Format("Rank={0}, Suit={1}, IsMagic={2}", RankName, SuitName, IsMagic);
        return str;
    }

    /// <summary>
    /// Equals override.
    /// </summary>
    /// <param name="other">The object to compare.</param>
    /// <returns>True if the object is the same; false otherwise.</returns>
    public override bool Equals(object other)
    {
        // If parameter is null return false.
        if (other == null)
        {
            return false;
        }

        // If parameter cannot be cast to Point return false.
        CardModel cardModel = other as CardModel;
        if ((object)cardModel == null)
        {
            return false;
        }

        // Return true if the fields match:
        return (SuitName == cardModel.SuitName) && (RankName == cardModel.RankName);
    }

    /// <summary>
    /// Equals override.
    /// </summary>
    /// <param name="other">The object to compare.</param>
    /// <returns>True if the object is the same; false otherwise.</returns>
    public bool Equals(CardModel other)
    {
        // If parameter is null return false:
        if ((object)other == null)
        {
            return false;
        }

        // Return true if the fields match:
        return (SuitName == other.SuitName) && (RankName == other.RankName);
    }

    /// <summary>
    /// Convert the hash value of the card.
    /// </summary>
    /// <returns>The hash value of the card.</returns>
    public override int GetHashCode()
    {
        return this.ToString().GetHashCode();
    }
}
