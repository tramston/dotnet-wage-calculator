namespace WageCalculator;

/// <summary>
/// Represents the schema for a health insurance, including the prime amount and a list of members.
/// </summary>
/// <typeparam name="T">The type of the identifier used for the health insurance member.</typeparam>
public class HealthInsuranceSchema<T>
{
    /// <summary>
    /// Gets or sets the prime, or primary monetary amount, associated with the health insurance.
    /// </summary>
    /// <value>The prime amount as a decimal.</value>
    public decimal Prime { get; set; }

    /// <summary>
    /// Gets or sets a list of member schemas associated with the health insurance.
    /// </summary>
    /// <value>A list of <see cref="HealthInsuranceMemberSchema{T}"/> objects, where T is the type of the member schema ID.</value>
#pragma warning disable IDE0028
    public List<HealthInsuranceMemberSchema<T>> MembersSchema { get; set; } = new();
#pragma warning restore IDE0028
}
