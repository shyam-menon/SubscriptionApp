using System.Collections.Generic;
using SubscriptionApp.API.Dtos.PseudoSkus;
using SubscriptionApp.API.Dtos.Refinements;

namespace SubscriptionApp.API.Services.Messaging.PseudoSkuCatalogService
{
    public class GetPseudoSkusByCategoryResponse
    {
         public string SelectedCategoryName { get; set; }
        public int SelectedCategory { get; set; }

        public IEnumerable<RefinementGroup> RefinementGroups { get; set; }

        public int NumberOfTitlesFound { get; set; }
        public int TotalNumberOfPages { get; set; }
        public int CurrentPage { get; set; }

        public IEnumerable<PseudoSkuSummaryView> Products { get; set; }
    }
}