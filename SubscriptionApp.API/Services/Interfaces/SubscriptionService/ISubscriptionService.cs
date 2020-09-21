using System.Threading.Tasks;
using SubscriptionApp.API.Models.Subscriptions;
using SubscriptionApp.API.Services.Messaging.SubscriptionService;

namespace SubscriptionApp.API.Services.Interfaces.SubscriptionService
{
    public interface ISubscriptionService
    {
        Task<GetSubscriptionResponse> GetSubscription(GetSubscriptionRequest subscriptionRequest);
        Task<CreateSubscriptionResponse> CreateSubscription(CreateSubscriptionRequest basketRequest);
        Task<ModifySubscriptionResponse> ModifySubscription(ModifySubscriptionRequest request);
    }
}