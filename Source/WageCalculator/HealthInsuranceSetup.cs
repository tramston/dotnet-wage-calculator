namespace WageCalculator;

/// <summary>
/// Represents the setup for health insurance, including a list of members and the overall health insurance coverage details.
/// </summary>
/// <typeparam name="T">The type of the identifier used for the health insurance member.</typeparam>
public class HealthInsuranceSetup<T>
{
    /// <summary>
    /// Gets or sets the list of health insurance members.
    /// </summary>
    /// <value>A list of <see cref="HealthInsuranceMember{T}"/> that contains all members covered under the health insurance plan.</value>
    public List<HealthInsuranceMember<T>> Members { get; set; } = new();

    /// <summary>
    /// Gets or sets a value indicating whether health insurance is applicable.
    /// </summary>
    /// <value>True if has health insurance, otherwise false.</value>
    public bool HasHealthInsurance { get; set; }

    /// <summary>
    /// Gets or sets the percentage of health insurance coverage applied to the members.
    /// </summary>
    /// <value>The percentage that indicates how much of the costs the health insurance covers.</value>
    public decimal HealthInsurancePercentage { get; set; }
}
