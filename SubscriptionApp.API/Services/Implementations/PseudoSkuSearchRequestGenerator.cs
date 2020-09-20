using System.Linq;
using SubscriptionApp.API.Infrastructure.Querying;
using SubscriptionApp.API.Models.PseudoSkus;
using SubscriptionApp.API.Services.Messaging.PseudoSkuCatalogService;

namespace SubscriptionApp.API.Services.Implementations
{
    //Query object pattern implementation
    public class PseudoSkuSearchRequestGenerator
    {
        public static Query CreateQueryFor(
                           GetPseudoSkusByCategoryRequest getPseudoSkusByCategoryRequest)
        {
            Query pseudoSkuQuery = new Query();
            Query colorQuery = new Query();
            Query functionQuery = new Query();
            Query sizeQuery = new Query();

            colorQuery.QueryOperator = QueryOperator.Or;
            foreach (int id in getPseudoSkusByCategoryRequest.ColorIds)
                colorQuery.Add(Criterion.Create<PseudoSku>(p => p.Color.Id, id,
                                                         CriteriaOperator.Equal));

            if (colorQuery.Criteria.Count() > 0)
                pseudoSkuQuery.AddSubQuery(colorQuery);

            functionQuery.QueryOperator = QueryOperator.Or;
            foreach (int id in getPseudoSkusByCategoryRequest.FunctionIds)
                functionQuery.Add(Criterion.Create<PseudoSku>(p => p.Function.Id, id,
                                                               CriteriaOperator.Equal));

            if (functionQuery.Criteria.Count() > 0)
                pseudoSkuQuery.AddSubQuery(functionQuery);

            sizeQuery.QueryOperator = QueryOperator.Or;
            foreach (int id in getPseudoSkusByCategoryRequest.SizeIds)
                sizeQuery.Add(Criterion.Create<PseudoSku>(p => p.Size.Id, id,
                                                               CriteriaOperator.Equal));

            if (sizeQuery.Criteria.Count() > 0)
                pseudoSkuQuery.AddSubQuery(sizeQuery);

            pseudoSkuQuery.Add(Criterion.Create<PseudoSku>(p => p.Category.Id,
                  getPseudoSkusByCategoryRequest.CategoryId, CriteriaOperator.Equal));

            return pseudoSkuQuery;
        }
    }
}