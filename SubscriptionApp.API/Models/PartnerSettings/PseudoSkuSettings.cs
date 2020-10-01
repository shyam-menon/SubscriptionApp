using System.Collections.Generic;

namespace SubscriptionApp.API.Models.PartnerSettings
{
    public class PseudoSkuSettings
    {
        public string DeviceDescription { get; set; }
        public FamilySettings FamilySettings { get; set; }
        public ICollection<PseudoSkuPlanSettings> SkuPlanSettings { get; set; }
    }
}