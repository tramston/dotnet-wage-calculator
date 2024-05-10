namespace WageCalculator;

/// <summary>
/// Represents a member within a health insurance plan, identifying the member and tracking the number of dependents or associated individuals.
/// </summary>
/// <typeparam name="T">The type of the identifier used for the health insurance member.</typeparam>
public class HealthInsuranceMember<T>
{
    /// <summary>
    /// Gets or sets the identifier for the health insurance member.
    /// </summary>
    /// <value>The identifier of the member, of generic type T.</value>
    public T Id { get; set; } = default!;

    /// <summary>
    /// Gets or sets the number of individuals or dependents associated with this member.
    /// </summary>
    /// <value>The count of associated individuals.</value>
    public int Members { get; set; }
}
