using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SubscriptionApp.API.Dtos.Categories;
using SubscriptionApp.API.Dtos.PseudoSkus;
using SubscriptionApp.API.Infrastructure.Querying;
using SubscriptionApp.API.Models.Categories;
using SubscriptionApp.API.Models.PseudoSkus;
using SubscriptionApp.API.Services.Interfaces.PseudoSkuCatalogService;
using SubscriptionApp.API.Services.Mapping.PseudoSkus;
using SubscriptionApp.API.Services.Messaging.PseudoSkuCatalogService;

namespace SubscriptionApp.API.Services.Implementations
{
    public class PseudoSkuCatalogService : IPseudoSkuCatalogService
    {
        private readonly IPseudoSkuTitleRepository _pseudoSkuTitleRepository;
        private readonly IPseudoSkuRepository _pseudoRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public PseudoSkuCatalogService(IPseudoSkuTitleRepository pseudoSkuTitleRepository,
                                       IPseudoSkuRepository pseudoRepository,
                                       ICategoryRepository categoryRepository, IMapper mapper)
        {
            _pseudoRepository = pseudoRepository;
            _categoryRepository = categoryRepository;            
            _pseudoSkuTitleRepository = pseudoSkuTitleRepository;
            _mapper = mapper;
        }
        public GetAllCategoriesResponse GetAllCategories()
        {
            GetAllCategoriesResponse response = new GetAllCategoriesResponse();
            IEnumerable<Category> categories = _categoryRepository.FindAll();
            response.Categories = _mapper.Map<IEnumerable<CategoryView>>(categories);

            return response;
        }

        public async Task<GetAllPseudoSkusResponse> GetAllPseudoSkus()
        {
             GetAllPseudoSkusResponse response = new GetAllPseudoSkusResponse();

            Query pseudoSkuQuery = new Query();

            pseudoSkuQuery.OrderByProperty = new OrderByClause() 
                { 
                    Desc = true, 
                    PropertyName = PropertyNameHelper.ResolvePropertyName<PseudoSkuTitle>(pt => pt.Price) 
                };

            var pseudoSkus = await _pseudoSkuTitleRepository.FindByAsync(pseudoSkuQuery, 0, 6);

            response.Products =  _mapper.Map<IEnumerable<PseudoSkuSummaryView>>(pseudoSkus);

            return response;
        }

        public GetPseudoSkuResponse GetPseudoSku(GetPseudoSkuRequest request)
        {
             GetPseudoSkuResponse response = new GetPseudoSkuResponse();

            PseudoSkuTitle pseudoSkuTitle = _pseudoSkuTitleRepository.FindBy(request.PseudoSkuId);

            response.Product = _mapper.Map<PseudoSkuView>(pseudoSkuTitle);

            return response;
        }

        public GetPseudoSkusByCategoryResponse GetPseudoSkusByCategory(GetPseudoSkusByCategoryRequest request)
        {
            GetPseudoSkusByCategoryResponse response;

            Query productQuery = PseudoSkuSearchRequestGenerator.CreateQueryFor(request);

            IEnumerable<PseudoSku> pseudoSkusMatchingRefinement = GetAllPseudoSkusMatchingQueryAndSort(request, productQuery);

            response = pseudoSkusMatchingRefinement.CreateProductSearchResultFrom(request);

            response.SelectedCategoryName =
                _categoryRepository.FindBy(request.CategoryId).Name;


            return response;
        }

         private IEnumerable<PseudoSku> GetAllPseudoSkusMatchingQueryAndSort(GetPseudoSkusByCategoryRequest request, Query pseudoSkuQuery)
        {
            IEnumerable<PseudoSku> pseudoSkusMatchingRefinement = _pseudoRepository.FindBy(pseudoSkuQuery);

            switch (request.SortBy)
            {
                case PseudoSkusSortBy.PriceLowToHigh:
                    pseudoSkusMatchingRefinement = pseudoSkusMatchingRefinement.OrderBy(p => p.Price);
                    break;
                case PseudoSkusSortBy.PriceHighToLow:
                    pseudoSkusMatchingRefinement = pseudoSkusMatchingRefinement.OrderByDescending(p => p.Price);
                    break;
            }
            return pseudoSkusMatchingRefinement;
        }
    }
}