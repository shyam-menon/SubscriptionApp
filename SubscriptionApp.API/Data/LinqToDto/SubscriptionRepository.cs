using SubscriptionApp.API.Infrastructure.UnitOfWork;
using SubscriptionApp.API.Models.Subscriptions;

namespace SubscriptionApp.API.Data.LinqToDto
{
    public class SubscriptionRepository: RepositoryLToD<Subscription, int>, ISubscriptionRepository
    {
        public SubscriptionRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }
}