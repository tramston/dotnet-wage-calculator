namespace WageCalculator;

/// <summary>
/// Defines the types of tax rates that can be applied to income within a tax bracket.
/// </summary>
public enum TaxBracketRateType
{
    /// <summary>
    /// Represents the primary tax rate. This is typically the standard tax rate applied to the base level of income.
    /// </summary>
    Primary,

    /// <summary>
    /// Represents a secondary tax rate. This rate could be applied for additional tax calculations such as surtaxes, alternative minimum taxes, or higher rates applicable to higher income brackets.
    /// </summary>
    Secondary,
}
