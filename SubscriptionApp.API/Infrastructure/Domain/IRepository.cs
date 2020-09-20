using System.Linq;

namespace SubscriptionApp.API.Infrastructure.Domain
{
    public interface IRepository<T>
    {
         IQueryable<T> Findall();

         T FindBy(int Id);

         void Add(T entity);
         void Save(T entity);
         void Remove(T entity);
    }
}