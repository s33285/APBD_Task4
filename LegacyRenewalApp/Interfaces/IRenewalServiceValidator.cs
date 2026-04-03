namespace LegacyRenewalApp.Interfaces;

public class IRenewalServiceValidator
{
    void ValidateInputs(int customerId, string planCode, int seatCount, string paymentMethod);
}