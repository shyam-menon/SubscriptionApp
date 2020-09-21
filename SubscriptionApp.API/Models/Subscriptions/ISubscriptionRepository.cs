using SubscriptionApp.API.Infrastructure.Domain;

namespace SubscriptionApp.API.Models.Subscriptions
{    public interface ISubscriptionRepository: IRepository<Subscription, int>
    {
    }    
}