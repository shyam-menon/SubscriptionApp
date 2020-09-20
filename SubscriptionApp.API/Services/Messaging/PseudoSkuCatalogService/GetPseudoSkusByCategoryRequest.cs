namespace SubscriptionApp.API.Services.Messaging.PseudoSkuCatalogService
{
    public class GetPseudoSkusByCategoryRequest
    {
        public GetPseudoSkusByCategoryRequest()
        {
            ColorIds = new int[0];
            FunctionIds = new int[0];
            SizeIds = new int[0];
        }
         public int CategoryId { get; set; }

        public int[] ColorIds { get; set; }
        public int[] FunctionIds { get; set; }
        public int[] SizeIds { get; set; }

        public PseudoSkusSortBy SortBy { get; set; }
        public int Index { get; set; }
        public int NumberOfResultsPerPage { get; set; }
        
    }
}