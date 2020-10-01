using System.Collections.Generic;

namespace SubscriptionApp.API.Models.PartnerSettings
{
    public class PseudoSkuTier
    {
        public int TierLevel { get; set; }
        public int RangeStart { get; set; }
        public int RangeEnd { get; set; }
        public IEnumerable<string> ServicesIncluded { get; set; }
        public IEnumerable<string> SolutionsIncluded { get; set; }
    }
}