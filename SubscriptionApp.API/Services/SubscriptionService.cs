using SubscriptionApp.API.Helpers;
using SubscriptionApp.API.Models;
using SubscriptionApp.API.Models.Subscriptions;

namespace SubscriptionApp.API.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        public decimal CalculateSubscriptionPrice(Subscription subscription)
        {
            return subscription.SubscriptionPrice;
        }
    }
}