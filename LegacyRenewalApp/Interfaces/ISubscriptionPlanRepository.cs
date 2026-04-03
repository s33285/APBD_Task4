namespace LegacyRenewalApp.Interfaces;

public class ISubscriptionPlanRepository
{
    SubscriptionPlan GetByCode(string code);
}
