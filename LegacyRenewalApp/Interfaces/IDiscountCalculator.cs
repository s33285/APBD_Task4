namespace LegacyRenewalApp.Interfaces;

public interface IDiscountCalculator
{
    (decimal DiscountAmount, string Notes) CalculateDiscount(
        Customer customer, 
        SubscriptionPlan plan, 
        int seatCount, 
        bool useLoyaltyPoints, 
        decimal baseAmount);
}