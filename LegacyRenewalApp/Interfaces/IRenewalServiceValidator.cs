namespace LegacyRenewalApp.Interfaces;

public interface IRenewalServiceValidator
{
    void ValidateInputs(int customerId, string planCode, int seatCount, string paymentMethod);
}