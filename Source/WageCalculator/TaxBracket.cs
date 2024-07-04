namespace WageCalculator;

/// <summary>
/// Represents a tax bracket, which defines the tax rates applicable at different income levels up to a specified threshold.
/// </summary>
public class TaxBracket
{
    /// <summary>
    /// Gets or sets the list of tax rates applicable within this tax bracket.
    /// Each <see cref="TaxBracketRate"/> represents a different type of tax rate, such as primary or secondary.
    /// </summary>
#pragma warning disable IDE0028
    public List<TaxBracketRate> Rates { get; set; } = new();
#pragma warning restore IDE0028

    /// <summary>
    /// Gets or sets the income threshold for this tax bracket.
    /// Tax calculations apply up to this threshold. If null, it indicates that this bracket extends to any income above the previous bracket's threshold without a defined upper limit.
    /// </summary>
    public decimal? Threshold { get; set; }
}
