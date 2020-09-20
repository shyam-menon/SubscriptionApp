using System.Collections.Generic;
using SubscriptionApp.API.Dtos.Categories;

namespace SubscriptionApp.API.Services.Messaging.PseudoSkuCatalogService
{
    public class GetAllCategoriesResponse
    {
        public IEnumerable<CategoryView> Categories { get; set; }
    }
}