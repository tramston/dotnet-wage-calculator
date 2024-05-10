namespace WageCalculator;

/// <summary>
/// Provides methods to calculate gross and net wages based on given tax brackets and contribution rates.
/// </summary>
public class WageCalculator
{
    private readonly List<TaxBracket> taxBrackets;

    /// <summary>
    /// Initializes a new instance of the <see cref="WageCalculator"/> class with specified tax brackets.
    /// </summary>
    /// <param name="taxBrackets">A list of tax brackets used for wage calculations.</param>
    public WageCalculator(List<TaxBracket> taxBrackets) => this.taxBrackets = taxBrackets;

    /// <summary>
    /// Calculates gross wage from a given net salary considering specified tax and contribution details.
    /// </summary>
    /// <param name="netSalary">The net salary from which to calculate the gross wage.</param>
    /// <param name="taxRateType">Specifies the type of tax rate to apply (primary or secondary).</param>
    /// <param name="contributionPercentage">The percentage of contributions (e.g., pension, health) deducted from the gross salary, defaults to 5.0%.</param>
    /// <param name="hasTaxes">Indicates whether tax deductions should be considered in the calculation, defaults to true.</param>
    /// <param name="taxBreakdown">If set to true, provides a detailed breakdown of taxes calculated at each bracket.</param>
    /// <returns>A <see cref="CalculatedWage"/> object containing details of the calculated gross wage, net salary, total tax, and contributions.</returns>
    public CalculatedWage CalculateFromNet(decimal netSalary, TaxBracketRateType taxRateType, decimal contributionPercentage = 5.0M, bool hasTaxes = true, bool taxBreakdown = false)
    {
        var calculatedSalary = new CalculatedWage();

        var totalTax = 0m;
        decimal previousThreshold = 0;

        var index = 0;
        foreach (var bracket in this.taxBrackets)
        {
            var taxRate = bracket.Rates.FirstOrDefault(x => x.RateType == taxRateType)?.Rate ?? 0;
            var currentThreshold = bracket.Threshold;
            decimal a = 0;
            decimal total = 0;
            if (taxRate > 0)
            {
                var c = (100 - (taxRate * 100)) / 100;
                a = (netSalary + totalTax - previousThreshold) / c;
                a = Math.Max(
                    Math.Min(a, currentThreshold == null ? a : (currentThreshold ?? netSalary) - previousThreshold), 0);
                total = a * taxRate;
            }

            totalTax += total;

            if (taxBreakdown)
            {
                if (bracket.Threshold == null)
                {
                    calculatedSalary.BreakDown.Add(new TaxBracketBreakDown
                    {
                        ThresholdFrom = this.taxBrackets[index - 1].Threshold,
                        Tax = total,
                    });
                }
                else
                {
                    calculatedSalary.BreakDown.Add(new TaxBracketBreakDown
                    {
                        ThresholdFrom = previousThreshold,
                        ThresholdTo = currentThreshold,
                        Tax = total,
                    });
                }
            }

            index++;

            if (!bracket.Threshold.HasValue)
            {
                break; // Last bracket
            }

            previousThreshold = bracket.Threshold.Value;
        }

        totalTax = Math.Round(totalTax, 2, MidpointRounding.AwayFromZero);
        var taxedSalary = netSalary + totalTax;

        var contribution = taxedSalary / (1 - (contributionPercentage / 100));
        contribution *= contributionPercentage / 100;
        contribution = Math.Round(contribution, 2, MidpointRounding.AwayFromZero);
        var gross =
            hasTaxes ? Math.Round(taxedSalary + contribution, 2, MidpointRounding.AwayFromZero) : taxedSalary;

        calculatedSalary.Gross = gross;
        calculatedSalary.Net = netSalary;
        calculatedSalary.Contribution = contribution;
        calculatedSalary.Tax = hasTaxes ? totalTax : 0;

        return calculatedSalary;
    }

    /// <summary>
    /// Calculates net wage from a given gross salary considering specified tax and contribution details.
    /// </summary>
    /// <param name="grossSalary">The gross salary from which to calculate the net wage.</param>
    /// <param name="taxRateType">Specifies the type of tax rate to apply (primary or secondary).</param>
    /// <param name="contributionPercentage">The percentage of contributions (e.g., pension, health) deducted from the gross salary, defaults to 5.0%.</param>
    /// <param name="hasTaxes">Indicates whether tax deductions should be considered in the calculation, defaults to true.</param>
    /// <param name="taxBreakdown">If set to true, provides a detailed breakdown of taxes calculated at each bracket.</param>
    /// <returns>A <see cref="CalculatedWage"/> object containing details of the calculated net wage, gross salary, total tax, and contributions.</returns>
    public CalculatedWage CalculateFromGross(decimal grossSalary, TaxBracketRateType taxRateType, decimal contributionPercentage = 5.0M, bool hasTaxes = true, bool taxBreakdown = false)
    {
        var calculatedSalary = new CalculatedWage();

        var contribution =
            Math.Round(grossSalary * contributionPercentage / 100, 2, MidpointRounding.AwayFromZero);
        var taxedSalary = Math.Round(grossSalary - contribution, 2, MidpointRounding.AwayFromZero);
        var remainingSalary = taxedSalary;
        var totalTax = 0m;
        decimal previousThreshold = 0;

        var index = 0;
        foreach (var bracket in this.taxBrackets)
        {
            if (remainingSalary <= 0)
            {
                break;
            }

            var currentThreshold = bracket.Threshold.HasValue
                ? bracket.Threshold.Value - previousThreshold
                : remainingSalary;
            var taxableAmount = Math.Min(remainingSalary, currentThreshold);

            var taxRate = bracket.Rates.FirstOrDefault(x => x.RateType == taxRateType)?.Rate ?? 0;
            var bracketTax = Math.Round(taxableAmount * taxRate, 2, MidpointRounding.AwayFromZero);
            totalTax += bracketTax;

            if (taxBreakdown)
            {
                if (bracket.Threshold == null)
                {
                    calculatedSalary.BreakDown.Add(new TaxBracketBreakDown
                    {
                        ThresholdFrom = this.taxBrackets[index - 1].Threshold,
                        Tax = bracketTax,
                    });
                }
                else
                {
                    calculatedSalary.BreakDown.Add(new TaxBracketBreakDown
                    {
                        ThresholdFrom = previousThreshold,
                        ThresholdTo = currentThreshold,
                        Tax = bracketTax,
                    });
                }
            }

            index++;

            remainingSalary = Math.Round(remainingSalary - taxableAmount, 2, MidpointRounding.AwayFromZero);
            if (!bracket.Threshold.HasValue)
            {
                break; // Last bracket
            }

            previousThreshold = bracket.Threshold.Value;
        }

        var net = hasTaxes ? Math.Round(taxedSalary - totalTax, 2, MidpointRounding.AwayFromZero) : taxedSalary;

        calculatedSalary.Gross = grossSalary;
        calculatedSalary.Net = net;
        calculatedSalary.Contribution = contribution;
        calculatedSalary.Tax = hasTaxes ? totalTax : 0;

        return calculatedSalary;
    }
}
