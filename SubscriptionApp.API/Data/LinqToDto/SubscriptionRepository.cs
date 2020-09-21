using System.Threading.Tasks;
using SubscriptionApp.API.Infrastructure.UnitOfWork;
using SubscriptionApp.API.Models.Subscriptions;

namespace SubscriptionApp.API.Data.LinqToDto
{
    public class SubscriptionLToDRepository: RepositoryLToD<Subscription, int>, ISubscriptionRepository
    {
        public SubscriptionLToDRepository(IUnitOfWork uow)
            : base(uow)
        {
        }

        public void Add<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAll()
        {
            throw new System.NotImplementedException();
        }

        Task<Subscription> ISubscriptionRepository.FindBy(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}