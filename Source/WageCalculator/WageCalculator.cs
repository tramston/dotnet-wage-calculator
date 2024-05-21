namespace WageCalculator;

/// <summary>
/// Provides methods to calculate gross and net wages based on given tax brackets and contribution rates.
/// </summary>
/// <typeparam name="T">The type of the identifier used for the health insurance member.</typeparam>
public class WageCalculator<T>
{
    private readonly List<TaxBracket> taxBrackets;
    private readonly HealthInsuranceSchema<T> healthInsuranceSchema;

    /// <summary>
    /// Initializes a new instance of the <see cref="WageCalculator{T}"/> class with specified tax brackets and health insurance schema.
    /// </summary>
    /// <param name="taxBrackets">A list of tax brackets used for wage calculations.</param>
    /// <param name="healthInsuranceSchema">The health insurance schema containing details about health insurance members.</param>
    public WageCalculator(List<TaxBracket> taxBrackets, HealthInsuranceSchema<T> healthInsuranceSchema)
    {
        this.taxBrackets = taxBrackets;
        this.healthInsuranceSchema = healthInsuranceSchema;
    }

    /// <summary>
    /// Calculates the gross wage from a given net salary considering specified tax and contribution details encapsulated in the <see cref="WageCalculationParameters{T}"/> object.
    /// </summary>
    /// <param name="wageCalculationParameters">The parameters including net salary, tax rate type, contribution percentage, whether taxes should be considered, and whether a tax breakdown should be provided.</param>
    /// <returns>A <see cref="CalculatedWage"/> object containing details of the calculated gross wage, net salary, total tax, and contributions.</returns>
    public CalculatedWage CalculateFromNet(WageCalculationParameters<T> wageCalculationParameters)
    {
        var calculatedSalary = new CalculatedWage();

        var preciseTotalTax = 0m;
        decimal previousThreshold = 0;

        var index = 0;
        foreach (var bracket in this.taxBrackets)
        {
            var taxRate =
                bracket.Rates.FirstOrDefault(x => x.RateType == wageCalculationParameters.TaxRateType)?.Rate ?? 0;
            var currentThreshold = bracket.Threshold;
            decimal a = 0;
            decimal total = 0;
            if (taxRate > 0)
            {
                var c = (100 - (taxRate * 100)) / 100;
                a = (wageCalculationParameters.Salary + preciseTotalTax - previousThreshold) / c;
                a = Math.Max(
                    Math.Min(a, currentThreshold == null ? a : (currentThreshold ?? wageCalculationParameters.Salary) - previousThreshold), 0);
                total = a * taxRate;
            }

            preciseTotalTax += total;

            if (wageCalculationParameters.TaxBreakdown)
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

        var totalTax = Math.Round(preciseTotalTax, 2, MidpointRounding.AwayFromZero);
        var taxedSalary = wageCalculationParameters.Salary + totalTax;

        var preciseContribution = taxedSalary / (1 - (wageCalculationParameters.ContributionPercentage / 100));
        preciseContribution *= wageCalculationParameters.ContributionPercentage / 100;
        var contribution = Math.Round(preciseContribution, 2, MidpointRounding.AwayFromZero);
        var gross =
            wageCalculationParameters.HasTaxes
                ? Math.Round(taxedSalary + contribution, 2, MidpointRounding.AwayFromZero)
                : taxedSalary;

        calculatedSalary.Gross = gross;
        calculatedSalary.Net = wageCalculationParameters.Salary;
        calculatedSalary.Contribution = contribution;
        calculatedSalary.Tax = wageCalculationParameters.HasTaxes ? totalTax : 0;

        if (!(wageCalculationParameters.HealthInsuranceSetup?.HasHealthInsurance ?? false))
        {
            return calculatedSalary;
        }

        return this.CalculateAdjustedSalaryWithHealthInsurance(wageCalculationParameters, calculatedSalary.Gross, preciseContribution, wageCalculationParameters.HasTaxes ? preciseTotalTax : 0, calculatedSalary.Net);
    }

    /// <summary>
    /// Calculates the net wage from a given gross salary considering specified tax and contribution details encapsulated in the <see cref="WageCalculationParameters{T}"/> object.
    /// </summary>
    /// <param name="wageCalculationParameters">The parameters including net salary, tax rate type, contribution percentage, whether taxes should be considered, and whether a tax breakdown should be provided.</param>
    /// <returns>A <see cref="CalculatedWage"/> object containing details of the calculated gross wage, net salary, total tax, and contributions.</returns>
    public CalculatedWage CalculateFromGross(WageCalculationParameters<T> wageCalculationParameters)
    {
        var calculatedSalary = new CalculatedWage();

        var preciseContribution = wageCalculationParameters.Salary * wageCalculationParameters.ContributionPercentage / 100;
        var contribution =
            Math.Round(preciseContribution, 2, MidpointRounding.AwayFromZero);
        var taxedSalary = Math.Round(wageCalculationParameters.Salary - contribution, 2, MidpointRounding.AwayFromZero);
        var remainingSalary = taxedSalary;
        var preciseTotalTax = 0m;
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

            var taxRate =
                bracket.Rates.FirstOrDefault(x => x.RateType == wageCalculationParameters.TaxRateType)?.Rate ?? 0;
            var priceBracketTax = taxableAmount * taxRate;
            var bracketTax = Math.Round(priceBracketTax, 2, MidpointRounding.AwayFromZero);
            totalTax += bracketTax;
            preciseTotalTax += priceBracketTax;

            if (wageCalculationParameters.TaxBreakdown)
            {
                if (bracket.Threshold == null)
                {
                    calculatedSalary.BreakDown.Add(
                        new TaxBracketBreakDown
                        {
                            ThresholdFrom = this.taxBrackets[index - 1].Threshold,
                            Tax = bracketTax,
                        });
                }
                else
                {
                    calculatedSalary.BreakDown.Add(
                        new TaxBracketBreakDown
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

        var net = wageCalculationParameters.HasTaxes
            ? Math.Round(taxedSalary - totalTax, 2, MidpointRounding.AwayFromZero)
            : taxedSalary;

        calculatedSalary.Gross = wageCalculationParameters.Salary;
        calculatedSalary.Net = net;
        calculatedSalary.Contribution = contribution;
        calculatedSalary.Tax = wageCalculationParameters.HasTaxes ? totalTax : 0;

        if (!(wageCalculationParameters.HealthInsuranceSetup?.HasHealthInsurance ?? false))
        {
            return calculatedSalary;
        }

        return this.CalculateAdjustedSalaryWithHealthInsurance(wageCalculationParameters, calculatedSalary.Gross, preciseContribution, wageCalculationParameters.HasTaxes ? preciseTotalTax : 0, calculatedSalary.Net);
    }

    /// <summary>
    /// Adjusts the calculated salary based on the health insurance contributions, recalculating gross and net salaries to include health insurance costs for gross salaries equal or bigger than 450.
    /// </summary>
    /// <param name="wageCalculationParameters">The parameters including tax rate type, contribution percentage, whether taxes should be considered, health insurance details, and whether a tax breakdown should be provided.</param>
    /// <param name="grossBaseSalary">The gross base salary without health insurance. </param>
    /// <param name="contribution">The "precise contribution" of the grossBaseSalary. </param>
    /// <param name="tax">The "precise tax" of the grossBaseSalary. </param>
    /// <returns>A <see cref="CalculatedWage"/> object that includes adjustments for health insurance contributions.</returns>
    private CalculatedWage CalculateAdjustedSalaryForGrossSalaryEqualOrBiggerThan450(WageCalculationParameters<T> wageCalculationParameters, decimal grossBaseSalary, decimal contribution, decimal tax)
    {
        var prime = Math.Round(this.healthInsuranceSchema.Prime, 2, MidpointRounding.AwayFromZero);
        var calculatedHealthInsuranceForGross = this.CalculateFromNet(
            new WageCalculationParameters<T>
            {
                Salary = prime *
                         (wageCalculationParameters.HealthInsuranceSetup.HealthInsurancePercentage / 100),
                HasTaxes = wageCalculationParameters.HasTaxes,
                TaxRateType = TaxBracketRateType.Secondary,
            });

        var adjustedSalaryAfterHealthInsurance = this.CalculateFromGross(
            new WageCalculationParameters<T>
            {
                Salary = calculatedHealthInsuranceForGross.Gross + grossBaseSalary,
                HasTaxes = wageCalculationParameters.HasTaxes,
                TaxBreakdown = wageCalculationParameters.TaxBreakdown,
                ContributionPercentage = wageCalculationParameters.ContributionPercentage,
                TaxRateType = wageCalculationParameters.TaxRateType,
            });

        var netBaseValue = grossBaseSalary - contribution - tax;
        decimal newNetValue;

        if (wageCalculationParameters.HealthInsuranceSetup.HealthInsurancePercentage == 100)
        {
            newNetValue = netBaseValue;
        }
        else if (wageCalculationParameters.HealthInsuranceSetup.HealthInsurancePercentage == 0)
        {
            newNetValue = netBaseValue - prime;
        }
        else
        {
            var calculatedHealthInsuranceForNet = this.CalculateFromNet(
                new WageCalculationParameters<T>
                {
                    Salary = prime *
                             ((100 - wageCalculationParameters.HealthInsuranceSetup.HealthInsurancePercentage) / 100),
                    HasTaxes = wageCalculationParameters.HasTaxes,
                    TaxRateType = TaxBracketRateType.Secondary,
                });
            newNetValue = netBaseValue - calculatedHealthInsuranceForNet.Net;
        }

        var totalPrime = prime;
        foreach (var member in wageCalculationParameters.HealthInsuranceSetup.Members)
        {
            var memberSchema =
                this.healthInsuranceSchema.MembersSchema.FirstOrDefault(x => x.Id != null && x.Id.Equals(member.Id));
            if (memberSchema == null)
            {
                continue;
            }

            var memberPrime = memberSchema.Prime * member.Members;
            totalPrime += memberPrime;
            newNetValue -= memberPrime;
        }

        adjustedSalaryAfterHealthInsurance.Net = Math.Round(newNetValue, 2, MidpointRounding.AwayFromZero);

        adjustedSalaryAfterHealthInsurance.HealthInsurancePrime = prime;
        var calculatedTax = adjustedSalaryAfterHealthInsurance.Gross - totalPrime -
                            adjustedSalaryAfterHealthInsurance.Contribution - adjustedSalaryAfterHealthInsurance.Net;
        if (calculatedTax != adjustedSalaryAfterHealthInsurance.Tax)
        {
            adjustedSalaryAfterHealthInsurance.Tax = calculatedTax;
        }

        adjustedSalaryAfterHealthInsurance.HealthInsurancePercentage =
            wageCalculationParameters.HealthInsuranceSetup.HealthInsurancePercentage;
        adjustedSalaryAfterHealthInsurance.HealthInsurancePrime = prime;
        adjustedSalaryAfterHealthInsurance.HealthInsuranceValue = calculatedHealthInsuranceForGross.Gross;
        return adjustedSalaryAfterHealthInsurance;
    }

    /// <summary>
    /// Adjusts the calculated salary based on the health insurance contributions, recalculating gross and net salaries to include health insurance costs for gross salaries smaller than 450.
    /// </summary>
    /// <param name="wageCalculationParameters">The parameters including tax rate type, contribution percentage, whether taxes should be considered, health insurance details, and whether a tax breakdown should be provided.</param>
    /// <param name="grossBaseSalary">The gross base salary without health insurance. </param>
    /// <param name="netValue">The Net Value. </param>
    /// <returns>A <see cref="CalculatedWage"/> object that includes adjustments for health insurance contributions.</returns>
    private CalculatedWage CalculateAdjustedSalaryForGrossSalarySmallerThan450(WageCalculationParameters<T> wageCalculationParameters, decimal grossBaseSalary, decimal netValue)
    {
        var prime = Math.Round(this.healthInsuranceSchema.Prime, 2, MidpointRounding.AwayFromZero);

        var netHealthInsurance = prime * (wageCalculationParameters.HealthInsuranceSetup.HealthInsurancePercentage / 100);
        var adjustedSalaryAfterHealthInsurance = this.CalculateFromNet(
            new WageCalculationParameters<T>
            {
                Salary = netHealthInsurance + netValue,
                HasTaxes = wageCalculationParameters.HasTaxes,
                TaxBreakdown = wageCalculationParameters.TaxBreakdown,
                ContributionPercentage = wageCalculationParameters.ContributionPercentage,
                TaxRateType = wageCalculationParameters.TaxRateType,
            });

        var healthInsurancePrime = adjustedSalaryAfterHealthInsurance.Gross - grossBaseSalary;
        var newNetValue = adjustedSalaryAfterHealthInsurance.Net;

        var totalPrime = prime;
        foreach (var member in wageCalculationParameters.HealthInsuranceSetup.Members)
        {
            var memberSchema =
                this.healthInsuranceSchema.MembersSchema.FirstOrDefault(x => x.Id != null && x.Id.Equals(member.Id));
            if (memberSchema == null)
            {
                continue;
            }

            var memberPrime = memberSchema.Prime * member.Members;
            totalPrime += memberPrime;
        }

        newNetValue -= totalPrime;

        adjustedSalaryAfterHealthInsurance.Net = Math.Round(newNetValue, 2, MidpointRounding.ToZero);

        adjustedSalaryAfterHealthInsurance.HealthInsurancePrime = prime;

        adjustedSalaryAfterHealthInsurance.HealthInsurancePercentage =
            wageCalculationParameters.HealthInsuranceSetup.HealthInsurancePercentage;
        adjustedSalaryAfterHealthInsurance.HealthInsuranceValue = healthInsurancePrime;
        return adjustedSalaryAfterHealthInsurance;
    }

    /// <summary>
    /// Adjusts the calculated salary based on the health insurance contributions, recalculating gross and net salaries to include health insurance costs.
    /// </summary>
    /// <param name="wageCalculationParameters">The parameters including tax rate type, contribution percentage, whether taxes should be considered, health insurance details, and whether a tax breakdown should be provided.</param>
    /// <param name="grossBaseSalary">The gross base salary without health insurance. </param>
    /// <param name="contribution">The "precise contribution" of the grossBaseSalary. </param>
    /// <param name="tax">The "precise tax" of the grossBaseSalary. </param>
    /// <param name="netValue">The Net Value. </param>
    /// <returns>A <see cref="CalculatedWage"/> object that includes adjustments for health insurance contributions.</returns>
    private CalculatedWage CalculateAdjustedSalaryWithHealthInsurance(WageCalculationParameters<T> wageCalculationParameters, decimal grossBaseSalary, decimal contribution, decimal tax, decimal netValue)
    {
        if (grossBaseSalary >= 450.00M)
        {
            return this.CalculateAdjustedSalaryForGrossSalaryEqualOrBiggerThan450(wageCalculationParameters, grossBaseSalary, contribution, tax);
        }

        return this.CalculateAdjustedSalaryForGrossSalarySmallerThan450(wageCalculationParameters, grossBaseSalary, netValue);
    }
}
