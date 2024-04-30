namespace WageCalculator;

/// <summary>
/// Represents the detailed breakdown of taxes within specific income thresholds of a tax bracket.
/// </summary>
public class TaxBracketBreakDown
{
    /// <summary>
    /// Gets or sets the starting threshold of income for this segment of the tax breakdown.
    /// If null, it indicates the start is from the first dollar or the minimum boundary of the tax bracket.
    /// </summary>
    public decimal? ThresholdFrom { get; set; }

    /// <summary>
    /// Gets or sets the ending threshold of income for this segment of the tax breakdown.
    /// If null, it indicates that this segment extends to the upper boundary of the tax bracket or has no defined upper limit.
    /// </summary>
    public decimal? ThresholdTo { get; set; }

    /// <summary>
    /// Gets or sets the total amount of tax applied within the income range from <see cref="ThresholdFrom"/> to <see cref="ThresholdTo"/>.
    /// </summary>
    public decimal Tax { get; set; }
}
