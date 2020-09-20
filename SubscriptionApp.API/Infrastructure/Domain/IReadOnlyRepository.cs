using System.Collections.Generic;
using System.Threading.Tasks;
using SubscriptionApp.API.Infrastructure.Querying;

namespace SubscriptionApp.API.Infrastructure.Domain
{
    public interface IReadOnlyRepository<T, TId> where T : IAggregateRoot
    {
        T FindBy(TId id);
        Task<T> FindByAsync(TId id);          
        IEnumerable<T> FindAll();
        Task<IEnumerable<T>> FindAllAsync();
        IEnumerable<T> FindBy(Query query);
        Task<IEnumerable<T>> FindByAsync(Query query);
        IEnumerable<T> FindBy(Query query, int index, int count);
        Task<IEnumerable<T>> FindByAsync(Query query, int index, int count);
    }
}