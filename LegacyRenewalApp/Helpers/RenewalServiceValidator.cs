using System;
using LegacyRenewalApp.Interfaces;

namespace LegacyRenewalApp.Helpers;

public class RenewalServiceValidator : IRenewalServiceValidator
{
    public void ValidateInputs(int customerId, string planCode, int seatCount, string paymentMethod)
    {
        if (customerId <= 0)
        {
            throw new ArgumentException("CustomerId must be a positive number.");
        }

        if (string.IsNullOrWhiteSpace(planCode))
        {
            throw new ArgumentException("PlanCode must be a non-empty string.");
        }

        if (seatCount <= 0)
        {
            throw new ArgumentException("SeatCount must be a positive number.");
        }

        if (string.IsNullOrWhiteSpace(paymentMethod))
        {
            throw new ArgumentException("PaymentMethod must be a non-empty string.");
        }
    }
}