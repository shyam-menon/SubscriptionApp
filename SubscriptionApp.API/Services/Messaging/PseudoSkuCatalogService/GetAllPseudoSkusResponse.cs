using System.Collections.Generic;
using SubscriptionApp.API.Dtos.PseudoSkus;

namespace SubscriptionApp.API.Services.Messaging.PseudoSkuCatalogService
{
    public class GetAllPseudoSkusResponse
    {
        public IEnumerable<PseudoSkuSummaryView> Products { get; set; }
    }
}