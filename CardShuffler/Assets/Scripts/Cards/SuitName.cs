
/// <summary>
/// SuitName representation.
/// </summary>
/// <remarks>
/// A <see cref="SuitName"/> is represented by a string. Implicit conversion operators
/// are provided to eliminate unnecessary casts and improve the source code readability.
/// </remarks>
/// <example>
///     SuitName name = "Hearts";
///     string s = name;
/// </example>
public class SuitName
{
    /// <summary>
    /// SuitName internal string value.
    /// </summary>
    private string value;

    /// <summary>
    /// Initializes a new instance of the <see cref="SuitName"/> class.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    public SuitName(string value)
    {
        this.value = value;
    }

    /// <summary>
    /// Implicit string to SuitName conversion operator.
    /// </summary>
    /// <param name="s">The string to convert.</param>
    /// <returns>The SuitName.</returns>
    public static implicit operator SuitName(string s)
    {
        return new SuitName(s);
    }

    /// <summary>
    /// Implicit SuitName to string conversion operator.
    /// </summary>
    /// <param name="s">The SuitName to convert.</param>
    /// <returns>The string.</returns>
    public static implicit operator string(SuitName s)
    {
        return s.value;
    }

    /// <summary>
    /// Overload == to do value comparison instead of reference comparison.
    /// </summary>
    /// <param name="a">The first object to compare</param>
    /// <param name="b">The second object to compare</param>
    /// <returns>true iff they are equal by value</returns>
    public static bool operator ==(SuitName a, SuitName b)
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
    public static bool operator !=(SuitName a, SuitName b)
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

        // If parameter cannot be cast to SuitName return false.
        SuitName r = other as SuitName;
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
    public bool Equals(SuitName other)
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
    /// <returns>A string representation of the SuitName.</returns>
    public override string ToString()
    {
        return value;
    }
}