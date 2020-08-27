using SubscriptionApp.API.Helpers;
using SubscriptionApp.API.Models;

namespace SubscriptionApp.API.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        public decimal CalculateSubscriptionPrice(Subscription subscription)
        {
            return subscription.SubscriptionPrice.AddOne();
        }
    }
}