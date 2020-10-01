using System.Collections.Generic;

namespace SubscriptionApp.API.Models.PartnerSettings
{
    public class PseudoSkuPlan
    {
        public IEnumerable<PseudoSkuTier> Tiers { get; set; }
    }
}