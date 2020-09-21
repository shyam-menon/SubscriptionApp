using System.Threading.Tasks;
using SubscriptionApp.API.Data;
using SubscriptionApp.API.Infrastructure.Domain;

namespace SubscriptionApp.API.Models.Subscriptions
{    
    public interface ISubscriptionRepository: IGenericRepository
    {
        Task<Subscription> FindBy(int id);
    }    
}