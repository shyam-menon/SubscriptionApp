using System.Collections.Generic;
using System.Threading.Tasks;
using SubscriptionApp.API.Models;

namespace SubscriptionApp.API.Data
{
    public interface ISubscriptionRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T:class;
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);
    }
}