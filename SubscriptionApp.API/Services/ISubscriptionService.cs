using SubscriptionApp.API.Models;

namespace SubscriptionApp.API.Services
{
    public interface ISubscriptionService
    {
         public decimal CalculateSubscriptionPrice(Subscription subscription);
    }
}