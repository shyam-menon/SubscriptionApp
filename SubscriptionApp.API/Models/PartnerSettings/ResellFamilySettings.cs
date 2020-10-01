using System.Collections.Generic;

namespace SubscriptionApp.API.Models.PartnerSettings
{
    public class ResellFamilySettings : FamilySettings
    {
        private readonly PseudoSkuPlan _plan;
        public ResellFamilySettings(PseudoSkuPlan plan)
        {
            _plan = plan;

        }
        public decimal RecommendedMargin { get; set; }
        public decimal FirstTimeUseMargin { get; set; }
        public decimal OverridenMargin { get; set; }
        public ICollection<PseudoSkuPlanSettings> PseudoSkuPlanSettings { get; set; }

        //Build the pseudo SKU plan settings from the pseudo SKU plan
        public ICollection<PseudoSkuPlanSettings> BuildPseudoSkuPlanSettingsFromPseudoSkuPlan(PseudoSkuPlan plan)
        {
            foreach (var tier in plan.Tiers)
            {
                PseudoSkuPlanSettings.Add(new PseudoSkuPlanSettings
                {
                    PageRangeStart = tier.RangeStart,
                    PageRangeEnd = tier.RangeEnd
                });
            }

            return PseudoSkuPlanSettings;
        }
    }
}