using System.Threading.Tasks;
using SubscriptionApp.API.Infrastructure.Domain;
using SubscriptionApp.API.Infrastructure.UnitOfWork;
using SubscriptionApp.API.Models.Subscriptions;

namespace SubscriptionApp.API.Data.LinqToDto
{
    public class SubscriptionLToDRepository: IUnitOfWorkRepository, ISubscriptionLToDRepository
    {
        private IUnitOfWork _uow;
        public SubscriptionLToDRepository(IUnitOfWork uow)            
        {
            _uow = uow;
        }

        public void Add(Subscription subscription)
        {
            _uow.RegisterNew(subscription, this);
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            //ADO.NET code to add the entity
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            //ADO.NET code to delete the entity
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            //ADO.NET code to update the entity
        }

        public void Remove(Subscription subscription)
        {
            _uow.RegisterRemoved(subscription, this);
        }

        public void Save(Subscription subscription)
        {
            _uow.RegisterAmended(subscription, this);
        }
    }
}