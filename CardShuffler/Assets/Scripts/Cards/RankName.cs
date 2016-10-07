
/// <summary>
/// RankName representation.
/// </summary>
/// <remarks>
/// A <see cref="RankName"/> is represented by a string. Implicit conversion operators
/// are provided to eliminate unnecessary casts and improve the source code readability.
/// </remarks>
/// <example>
///     RankName name = "Ace";
///     string s = name;
/// </example>
public class RankName
{
    /// <summary>
    /// RankName internal string value.
    /// </summary>
    private string value;

    /// <summary>
    /// Initializes a new instance of the <see cref="RankName"/> class.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    public RankName(string value)
    {
        this.value = value;
    }

    /// <summary>
    /// Implicit string to RankName conversion operator.
    /// </summary>
    /// <param name="s">The string to convert.</param>
    /// <returns>The RankName.</returns>
    public static implicit operator RankName(string s)
    {
        return new RankName(s);
    }

    /// <summary>
    /// Implicit RankName to string conversion operator.
    /// </summary>
    /// <param name="r">The RankName to convert.</param>
    /// <returns>The string.</returns>
    public static implicit operator string(RankName r)
    {
        return r.value;
    }

    /// <summary>
    /// Overload == to do value comparison instead of reference comparison.
    /// </summary>
    /// <param name="a">The first object to compare</param>
    /// <param name="b">The second object to compare</param>
    /// <returns>true iff they are equal by value</returns>
    public static bool operator ==(RankName a, RankName b)
    {
        if (object.ReferenceEquals(a, b))
        {
            return true;
        }
        if (((object)a == null) || ((object)b == null))
        {
            return false;
        }
        return a.Equals(b);
    }

    /// <summary>
    /// Overload != to do value comparison instead of reference comparison.
    /// </summary>
    /// <param name="a">The first object to compare</param>
    /// <param name="b">The second object to compare</param>
    /// <returns>true iff they are not equal by value</returns>
    public static bool operator !=(RankName a, RankName b)
    {
        return !(a == b);
    }

    /// <summary>
    /// Check for equality
    /// </summary>
    /// <param name="other"> object to check against </param>
    /// <returns> true if objects are equal </returns>
    public override bool Equals(object other)
    {
        // If parameter is null return false.
        if (other == null)
        {
            return false;
        }

        // If parameter cannot be cast to RankName return false.
        RankName r = other as RankName;
        if ((object)r == null)
        {
            return false;
        }

        // Return true if the fields match:
        return value == r.value;
    }

    /// <summary>
    /// Check for equality
    /// </summary>
    /// <param name="other"> object to check against </param>
    /// <returns> true if objects are equal </returns>
    public bool Equals(RankName other)
    {
        // If parameter is null return false:
        if ((object)other == null)
        {
            return false;
        }

        // Return true if the fields match:
        return value == other.value;
    }

    /// <summary>
    /// Get hash code
    /// </summary>
    /// <returns>Hash code</returns>
    public override int GetHashCode()
    {
        return value.GetHashCode();
    }

    /// <summary>
    /// String representation.
    /// </summary>
    /// <returns>A string representation of the RankName.</returns>
    public override string ToString()
    {
        return value;
    }
}