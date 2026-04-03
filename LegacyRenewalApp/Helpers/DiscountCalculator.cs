using System.Text;
using LegacyRenewalApp.Interfaces;

namespace LegacyRenewalApp.Helpers;

public class DiscountCalculator : IDiscountCalculator
    {
        public (decimal DiscountAmount, string Notes) CalculateDiscount(
            Customer customer,
            SubscriptionPlan plan,
            int seatCount,
            bool useLoyaltyPoints,
            decimal baseAmount)
    {
        decimal discountAmount = 0m;
        var notes = new StringBuilder();
        
        if (customer.Segment == "Silver")
        {
            discountAmount += baseAmount * 0.05m;
            notes.Append("silver discount; ");
        }
        else if (customer.Segment == "Gold")
        {
            discountAmount += baseAmount * 0.10m;
            notes.Append("gold discount; ");
        }
        else if (customer.Segment == "Platinum")
        {
            discountAmount += baseAmount * 0.15m;
            notes.Append("platinum discount; ");
        }
        else if (customer.Segment == "Education" && plan.IsEducationEligible)
        {
            discountAmount += baseAmount * 0.20m;
            notes.Append("education discount; ");
        }

        if (customer.YearsWithCompany >= 5)
        {
            discountAmount += baseAmount * 0.07m;
            notes.Append("long-term loyalty discount; ");
        }
        else if (customer.YearsWithCompany >= 2)
        {
            discountAmount += baseAmount * 0.03m;
            notes.Append("basic loyalty discount; ");
        }

        if (seatCount >= 50)
        {
            discountAmount += baseAmount * 0.12m;
            notes.Append("large team discount; ");
        }
        else if (seatCount >= 20)
        {
            discountAmount += baseAmount * 0.08m;
            notes.Append("medium team discount; ");
        }
        else if (seatCount >= 10)
        {
            discountAmount += baseAmount * 0.04m;
            notes.Append("small team discount; ");
        }

        if (useLoyaltyPoints && customer.LoyaltyPoints > 0)
        {
            int pointsToUse = customer.LoyaltyPoints > 200 ? 200 : customer.LoyaltyPoints;
            discountAmount += pointsToUse;
            notes.Append($"loyalty points used: {pointsToUse}; ");
        }
        
        return (discountAmount, notes.ToString());
    }
}