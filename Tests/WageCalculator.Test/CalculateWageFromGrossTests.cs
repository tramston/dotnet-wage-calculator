namespace WageCalculator.Test;

using Xunit;

public class CalculateWageFromGrossTests
{
    [Fact]
    public void CalculatePaycheck_Primary1000()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromGross(1000, TaxBracketRateType.Primary, 5M, true, true);
        Assert.Equal(877.20M, calculatedSalary.Net);
        Assert.Equal(50.00M, calculatedSalary.Contribution);
        Assert.Equal(72.80M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Secondary1000()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromGross(1000, TaxBracketRateType.Secondary);
        Assert.Equal(855.00M, calculatedSalary.Net);
        Assert.Equal(50.00M, calculatedSalary.Contribution);
        Assert.Equal(95.00M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Primary80()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromGross(80, TaxBracketRateType.Primary);
        Assert.Equal(76.00M, calculatedSalary.Net);
        Assert.Equal(4.00M, calculatedSalary.Contribution);
        Assert.Equal(0, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Secondary80()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromGross(80, TaxBracketRateType.Secondary);
        Assert.Equal(68.40M, calculatedSalary.Net);
        Assert.Equal(4.00M, calculatedSalary.Contribution);
        Assert.Equal(7.60M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Primary81()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromGross(81, TaxBracketRateType.Primary);
        Assert.Equal(76.95M, calculatedSalary.Net);
        Assert.Equal(4.05M, calculatedSalary.Contribution);
        Assert.Equal(0, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Secondary81()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromGross(81, TaxBracketRateType.Secondary);
        Assert.Equal(69.25M, calculatedSalary.Net);
        Assert.Equal(4.05M, calculatedSalary.Contribution);
        Assert.Equal(7.70M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Primary250()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromGross(250, TaxBracketRateType.Primary);
        Assert.Equal(231.20M, calculatedSalary.Net);
        Assert.Equal(12.50M, calculatedSalary.Contribution);
        Assert.Equal(6.30M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Secondary250()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromGross(250, TaxBracketRateType.Secondary);
        Assert.Equal(213.75M, calculatedSalary.Net);
        Assert.Equal(12.50M, calculatedSalary.Contribution);
        Assert.Equal(23.75M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Primary251()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromGross(251, TaxBracketRateType.Primary);
        Assert.Equal(232.11M, calculatedSalary.Net);
        Assert.Equal(12.55M, calculatedSalary.Contribution);
        Assert.Equal(6.34M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Secondary251()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromGross(251, TaxBracketRateType.Secondary);
        Assert.Equal(214.60M, calculatedSalary.Net);
        Assert.Equal(12.55M, calculatedSalary.Contribution);
        Assert.Equal(23.85M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Primary450()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromGross(450, TaxBracketRateType.Primary);
        Assert.Equal(406.50M, calculatedSalary.Net);
        Assert.Equal(22.50M, calculatedSalary.Contribution);
        Assert.Equal(21.00M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Secondary450()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromGross(450, TaxBracketRateType.Secondary);
        Assert.Equal(384.75M, calculatedSalary.Net);
        Assert.Equal(22.50M, calculatedSalary.Contribution);
        Assert.Equal(42.75M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Primary451()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromGross(451, TaxBracketRateType.Primary);
        Assert.Equal(407.37M, calculatedSalary.Net);
        Assert.Equal(22.55M, calculatedSalary.Contribution);
        Assert.Equal(21.08M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Secondary451()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromGross(451, TaxBracketRateType.Secondary);
        Assert.Equal(385.60M, calculatedSalary.Net);
        Assert.Equal(22.55M, calculatedSalary.Contribution);
        Assert.Equal(42.85M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Primary1500()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromGross(1500, TaxBracketRateType.Primary);
        Assert.Equal(1304.70M, calculatedSalary.Net);
        Assert.Equal(75.00M, calculatedSalary.Contribution);
        Assert.Equal(120.30M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Secondary1500()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromGross(1500, TaxBracketRateType.Secondary);
        Assert.Equal(1282.50M, calculatedSalary.Net);
        Assert.Equal(75.00M, calculatedSalary.Contribution);
        Assert.Equal(142.50M, calculatedSalary.Tax);
    }

    [Fact]
    public void CalculatePaycheck_Primary1714_29()
    {
        var salaryCalculator = new WageCalculator(DefaultTaxBrackets.GetList());
        var calculatedSalary = salaryCalculator.CalculateFromGross(1714.29M, TaxBracketRateType.Primary);
        Assert.Equal(1487.92M, calculatedSalary.Net);
        Assert.Equal(85.71M, calculatedSalary.Contribution);
        Assert.Equal(140.66M, calculatedSalary.Tax);
    }
}
