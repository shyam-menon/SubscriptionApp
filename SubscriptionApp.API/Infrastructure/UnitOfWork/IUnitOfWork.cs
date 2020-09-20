using SubscriptionApp.API.Infrastructure.Domain;

namespace SubscriptionApp.API.Infrastructure.UnitOfWork
{
     public interface IUnitOfWork
    {
        void RegisterAmended(IAggregateRoot entity,
                             IUnitOfWorkRepository unitofWorkRepository);
        void RegisterNew(IAggregateRoot entity,
                         IUnitOfWorkRepository unitofWorkRepository);
        void RegisterRemoved(IAggregateRoot entity,
                             IUnitOfWorkRepository unitofWorkRepository);
        void Commit();
    }
}