namespace WageCalculator.Test;

using Xunit;

/// <summary>
/// Contains unit tests for the CalculateFromGross method of the WageCalculator class, testing various scenarios
/// to ensure correct calculations of gross-to-net wage conversions using different tax rates and thresholds.
/// </summary>
public class CalculateWageWithHealthInsuranceAndAdditionalMembersTests
{
    private readonly WageCalculator<string> wageCalculator;

    /// <summary>
    /// Initializes a new instance of the <see cref="CalculateWageWithHealthInsuranceAndAdditionalMembersTests"/> class.
    /// </summary>
    public CalculateWageWithHealthInsuranceAndAdditionalMembersTests() => this.wageCalculator =
        new WageCalculator<string>(DefaultTaxBrackets.GetList(), DefaultHealthInsuranceSchema.GetSchema());

    /// <summary>
    /// Tests the calculation from a gross salary of 1000 using the primary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary1000_100PercentageHealthInsurance_AndTwoAdultsChildren()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 1000,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string>
                {
                    HealthInsurancePercentage = 100.00M,
                    Members = new List<HealthInsuranceMember<string>>
                    {
                        new HealthInsuranceMember<string>()
                        {
                            Members = 2, Id = HealthInsuranceMemberTypes.ADULTSCHILDREN,
                        },
                    },
                },
            });
        Assert.Equal(1032.75M, calculatedSalary.Gross);
        Assert.Equal(821.20M, calculatedSalary.Net);
        Assert.Equal(51.64M, calculatedSalary.Contribution);
        Assert.Equal(75.91M, calculatedSalary.Tax);
    }

    /// <summary>
    /// Tests the calculation from a gross salary of 1000 using the primary tax rate,
    /// verifying correct net salary, contribution, and tax calculations.
    /// </summary>
    [Fact]
    public void CalculatePaycheck_Primary1000_100PercentageHealthInsurance_AndTwoAdultsChildrenAndOneParent()
    {
        var calculatedSalary = this.wageCalculator.CalculateFromGross(
            new WageCalculationParameters<string>
            {
                Salary = 1000,
                TaxRateType = TaxBracketRateType.Primary,
                HealthInsuranceSetup = new HealthInsuranceSetup<string>
                {
                    HealthInsurancePercentage = 100.00M,
                    Members = new List<HealthInsuranceMember<string>>
                    {
                        new HealthInsuranceMember<string>()
                        {
                            Members = 2, Id = HealthInsuranceMemberTypes.ADULTSCHILDREN,
                        },
                        new HealthInsuranceMember<string>()
                        {
                            Members = 1, Id = HealthInsuranceMemberTypes.PARENTS,
                        },
                    },
                },
            });
        Assert.Equal(1032.75M, calculatedSalary.Gross);
        Assert.Equal(793.20M, calculatedSalary.Net);
        Assert.Equal(51.64M, calculatedSalary.Contribution);
        Assert.Equal(75.91M, calculatedSalary.Tax);
    }
}
