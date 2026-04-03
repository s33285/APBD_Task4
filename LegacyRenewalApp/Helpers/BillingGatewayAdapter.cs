using LegacyRenewalApp.Interfaces;

namespace LegacyRenewalApp.Helpers;

public class BillingGatewayAdapter : IBillingGateway
{
    public void SaveInvoice(RenewalInvoice invoice)
    {
        LegacyBillingGateway.SaveInvoice(invoice);
    }

    public void SendEmail(string email, string subject, string body)
    {
        LegacyBillingGateway.SendEmail(email, subject, body);
    }
}