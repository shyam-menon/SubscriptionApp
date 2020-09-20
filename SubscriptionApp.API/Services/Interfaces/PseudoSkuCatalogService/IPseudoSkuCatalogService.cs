using System.Threading.Tasks;
using SubscriptionApp.API.Services.Messaging.PseudoSkuCatalogService;

namespace SubscriptionApp.API.Services.Interfaces.PseudoSkuCatalogService
{
    public interface IPseudoSkuCatalogService
    {
        Task<GetAllPseudoSkusResponse> GetAllPseudoSkus();
        GetPseudoSkusByCategoryResponse GetPseudoSkusByCategory(
                                         GetPseudoSkusByCategoryRequest request);
        GetPseudoSkuResponse GetPseudoSku(GetPseudoSkuRequest request);

        GetAllCategoriesResponse GetAllCategories();
    }
}