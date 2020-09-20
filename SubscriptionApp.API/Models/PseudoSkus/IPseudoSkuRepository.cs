using SubscriptionApp.API.Infrastructure.Domain;

namespace SubscriptionApp.API.Models.PseudoSkus
{
    public interface IPseudoSkuRepository : IReadOnlyRepository<PseudoSku, int>
    {
         
    }
}