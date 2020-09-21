using System.Collections.Generic;
using System.Threading.Tasks;
using SubscriptionApp.API.Models;

namespace SubscriptionApp.API.Data
{
    public interface IUserRepository
    {
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);
    }
}