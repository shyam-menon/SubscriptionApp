using SubscriptionApp.API.Models.Subscriptions;

namespace SubscriptionApp.API.Data.LinqToDto
{
    public interface ISubscriptionLToDRepository
    {
         void Save(Subscription subscription);
         void Add(Subscription subscription);
         void Remove(Subscription subscription);
    }
}