using SubscriptionApp.API.Models.Subscriptions;

namespace SubscriptionApp.API.Services
{
    public interface ISubscriptionService
    {
         public decimal CalculateSubscriptionPrice(Subscription subscription);
    }
}