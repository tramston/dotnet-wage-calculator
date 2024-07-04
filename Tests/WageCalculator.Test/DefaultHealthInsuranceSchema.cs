namespace WageCalculator.Test;

/// <summary>
/// Provides a default health insurance schema for demonstration or initial setup purposes.
/// </summary>
public static class DefaultHealthInsuranceSchema
{
    /// <summary>
    /// Gets a default health insurance schema with predefined members and primes.
    /// </summary>
    /// <param name="prime">Prime Value.</param>
    /// <returns>A <see cref="HealthInsuranceSchema{T}"/> where T is string, populated with default values.</returns>
    public static HealthInsuranceSchema<string> GetSchema(decimal prime = 28.00M) => new()
    {
        Prime = prime,
        MembersSchema = new List<HealthInsuranceMemberSchema<string>>
        {
            new HealthInsuranceMemberSchema<string> { Id = HealthInsuranceMemberTypes.PARENTS, Prime = 28.00M },
            new HealthInsuranceMemberSchema<string> { Id = HealthInsuranceMemberTypes.PARTNERS, Prime = 28.00M },
            new HealthInsuranceMemberSchema<string> { Id = HealthInsuranceMemberTypes.CHILDREN, Prime = 28.00M },
            new HealthInsuranceMemberSchema<string> { Id = HealthInsuranceMemberTypes.ADULTSCHILDREN, Prime = 28.00M },
        },
    };
}
