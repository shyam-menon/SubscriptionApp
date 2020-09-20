using System.Collections.Generic;
using SubscriptionApp.API.Dtos.Refinements;
using SubscriptionApp.API.Models.PseudoSkus;

namespace SubscriptionApp.API.Services.Mapping.PseudoSkus
{
    public static class IPseudoSkuAttributeMapper
    {
        public static RefinementGroup ConvertToRefinementGroup(
                                this IEnumerable<IPseudoSkuAttribute> pseudoSkuAttributes,
                                RefinementGroupings refinementGroupType)
        {
            RefinementGroup refinementGroup = new RefinementGroup()
            {
                Name = refinementGroupType.ToString(),
                GroupId = (int)refinementGroupType
            };
            
            foreach (var refinement in refinementGroup.Refinements)
            {
                foreach (var pseudoSkuAttribute in pseudoSkuAttributes)
                {
                    pseudoSkuAttribute.Id = refinement.Id;
                    pseudoSkuAttribute.Name = refinement.Name;
                }
            }   

            return refinementGroup;
        }
    }
}