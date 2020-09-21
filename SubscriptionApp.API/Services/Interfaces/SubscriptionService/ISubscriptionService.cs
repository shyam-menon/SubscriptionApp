using SubscriptionApp.API.Models.Subscriptions;

namespace SubscriptionApp.API.Services.Interfaces.SubscriptionService
{
    public interface ISubscriptionService
    {
         public decimal CalculateSubscriptionPrice(Subscription subscription);
    }
}