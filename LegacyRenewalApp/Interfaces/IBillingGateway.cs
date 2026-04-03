namespace LegacyRenewalApp.Interfaces;

public class IBillingGateway
{
    void SaveInvoice(RenewalInvoice invoice);
    void SendEmail(string email, string subject, string body);

}