using System.Collections.Generic;
using System.Linq;
using SubscriptionApp.API.Dtos.PseudoSkus;
using SubscriptionApp.API.Dtos.Refinements;
using SubscriptionApp.API.Models.PseudoSkus;
using SubscriptionApp.API.Services.Messaging.PseudoSkuCatalogService;

namespace SubscriptionApp.API.Services.Mapping.PseudoSkus
{
    public static class PseudoSkuMapper
    {
        public static GetPseudoSkusByCategoryResponse CreateProductSearchResultFrom(this IEnumerable<PseudoSku> pseudoSkusMatchingRefinement, GetPseudoSkusByCategoryRequest request)
        {
            var pseudoSkuSearchResultView = new GetPseudoSkusByCategoryResponse();

            IEnumerable<PseudoSkuTitle> pseudoSkusFound = pseudoSkusMatchingRefinement.Select(p => p.Title).Distinct();

            pseudoSkuSearchResultView.SelectedCategory = request.CategoryId;

            pseudoSkuSearchResultView.NumberOfTitlesFound = pseudoSkusFound.Count();

            pseudoSkuSearchResultView.TotalNumberOfPages = NoOfResultPagesGiven(request.NumberOfResultsPerPage,
                                                                              pseudoSkuSearchResultView.NumberOfTitlesFound);

            pseudoSkuSearchResultView.RefinementGroups = GenerateAvailableProductRefinementsFrom(pseudoSkusFound);

            pseudoSkuSearchResultView.Products = CropProductListToSatisfyGivenIndex(request.Index, request.NumberOfResultsPerPage, pseudoSkusFound);

            return pseudoSkuSearchResultView;
        }

         public static IEnumerable<PseudoSkuSummaryView> ConvertToPseudoSkuViews(
                                                this IEnumerable<PseudoSkuTitle> pseudoSkus)
        {
            var pseudoSkuSummaryView = new List<PseudoSkuSummaryView>();

            foreach (var psku in pseudoSkus)
            {
                var psv = new PseudoSkuSummaryView();
                psv.ModelName = psku.Model.Name;
                psv.Name = psku.Name;
                psv.Price = psku.Price.ToString();

                pseudoSkuSummaryView.Add(psv);
            }

            return pseudoSkuSummaryView;
        }

        private static IEnumerable<PseudoSkuSummaryView> CropProductListToSatisfyGivenIndex(int pageIndex, int numberOfResultsPerPage, IEnumerable<PseudoSkuTitle> productsFound)
        {
            if (pageIndex > 1)
            {
                int numToSkip = (pageIndex - 1) * numberOfResultsPerPage;
                return productsFound.Skip(numToSkip).Take(numberOfResultsPerPage).ConvertToPseudoSkuViews();
            }
            else
                return productsFound.Take(numberOfResultsPerPage).ConvertToPseudoSkuViews();
        }

        private static int NoOfResultPagesGiven(int numberOfResultsPerPage, int numberOfTitlesFound)
        {
            if (numberOfTitlesFound < numberOfResultsPerPage)
                return 1;
            else
            {
                return (numberOfTitlesFound / numberOfResultsPerPage) + (numberOfTitlesFound % numberOfResultsPerPage);
            }
        }

        private static IList<RefinementGroup> GenerateAvailableProductRefinementsFrom(IEnumerable<PseudoSkuTitle> pseudoSkusFound)
        {
            var functionRefinementGroup = pseudoSkusFound.Select(p => p.Function).Distinct().ToList()
                                       .ConvertAll<IPseudoSkuAttribute>(f => (IPseudoSkuAttribute)f).ConvertToRefinementGroup(RefinementGroupings.function);
            var colorsRefinementGroup = pseudoSkusFound.Select(p => p.Color).Distinct().ToList()
                                       .ConvertAll<IPseudoSkuAttribute>(c => (IPseudoSkuAttribute)c).ConvertToRefinementGroup(RefinementGroupings.color);
            var sizesRefinementGroup = (from p in pseudoSkusFound
                                        from si in p.PseudoSkus
                                        select si.Size).Distinct().ToList()
                                       .ConvertAll<IPseudoSkuAttribute>(s => (IPseudoSkuAttribute)s).ConvertToRefinementGroup(RefinementGroupings.size);

            IList<RefinementGroup> refinementGroups = new List<RefinementGroup>();

            refinementGroups.Add(functionRefinementGroup);
            refinementGroups.Add(colorsRefinementGroup);
            refinementGroups.Add(sizesRefinementGroup);
            return refinementGroups;
        }
    }
}