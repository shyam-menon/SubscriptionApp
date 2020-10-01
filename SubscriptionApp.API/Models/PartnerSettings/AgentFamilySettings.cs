using System.Collections.Generic;

namespace SubscriptionApp.API.Models.PartnerSettings
{
    public class AgentFamilySettings : FamilySettings
    {
        private readonly PseudoSkuPlan _plan;
        public AgentFamilySettings(PseudoSkuPlan plan)
        {
            _plan = plan;
            BuildPseudoSkuPlanSettingsFromPseudoSkuPlan(_plan);
        }
        public decimal RecommendedCommission { get; set; }
        public decimal DefaultCommission { get; set; }
        public decimal OverridenCommission { get; set; }
        public decimal MinimumCommission { get; set; }
        public decimal MaximumCommission { get; set; }
        public List<PseudoSkuPlanSettings> PseudoSkuPlanSettings { get; set; } = new List<PseudoSkuPlanSettings>();

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