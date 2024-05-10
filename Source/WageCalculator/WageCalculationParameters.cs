namespace WageCalculator;

public class CalculateWage
{
    public decimal NetSalary { get; set; }
    public decimal GrossSalary { get; set; }
    public TaxBracketRateType TaxBracketRateType { get; set; }
    public decimal ContributionPercentage { get; set; } = 0.00M;
    public bool HasTaxes { get; set; }
    public bool TaxBreakdown { get; set; }
}
