namespace LegacyRenewalApp.Helpers;

public static class FeeCalculator
{
    public static decimal CalculateSupportFee(string normalizedPlanCode, bool includePremiumSupport)
    {
        if (!includePremiumSupport) return 0m;

        if (normalizedPlanCode == "START") return 250m;
        if (normalizedPlanCode == "PRO") return 400m;
        if (normalizedPlanCode == "ENTERPRISE") return 700m;

        return 0m;
    }

    public static decimal CalculatePaymentFee(string normalizedPaymentMethod, decimal subtotalAfterDiscount, decimal supportFee)
    {
        decimal baseAmount = subtotalAfterDiscount + supportFee;

        if (normalizedPaymentMethod == "CARD")
        {
            return baseAmount * 0.02m;
        }
        else if (normalizedPaymentMethod == "BANK_TRANSFER")
        {
            return baseAmount * 0.01m;
        }
        else if (normalizedPaymentMethod == "PAYPAL")
        {
            return baseAmount * 0.035m;
        }
        else if (normalizedPaymentMethod == "INVOICE")
        {
            return 0m;
        }

        throw new System.ArgumentException("Unsupported payment method");
    }

    public static decimal GetTaxRateForCountry(string country)
    {
        decimal taxRate = 0.20m;
        if (country == "Poland") taxRate = 0.23m;
        else if (country == "Germany") taxRate = 0.19m;
        else if (country == "Czech Republic") taxRate = 0.21m;
        else if (country == "Norway") taxRate = 0.25m;

        return taxRate;
    }
}