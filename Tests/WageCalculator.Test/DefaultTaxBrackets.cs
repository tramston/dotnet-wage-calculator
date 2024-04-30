namespace WageCalculator.Test;

public class DefaultTaxBrackets
{
    public static List<TaxBracket> GetList() => new()
    {
        new()
        {
            Threshold = 80,
            Rates =
                new()
                {
                    new() { Rate = 0, RateType = TaxBracketRateType.Primary, },
                    new() { Rate = 0.1M, RateType = TaxBracketRateType.Secondary, },
                },
        },
        new()
        {
            Threshold = 250,
            Rates =
                new()
                {
                    new() { Rate = 0.04M, RateType = TaxBracketRateType.Primary, },
                    new() { Rate = 0.1M, RateType = TaxBracketRateType.Secondary, },
                },
        },
        new()
        {
            Threshold = 450,
            Rates = new()
            {
                new() { Rate = 0.08M, RateType = TaxBracketRateType.Primary, },
                new() { Rate = 0.1M, RateType = TaxBracketRateType.Secondary, },
            },
        },
        new()
        {
            Rates = new()
            {
                new() { Rate = 0.1M, RateType = TaxBracketRateType.Primary, },
                new() { Rate = 0.1M, RateType = TaxBracketRateType.Secondary, },
            },
        },
    };
}
