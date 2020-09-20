using SubscriptionApp.API.Infrastructure.UnitOfWork;
using SubscriptionApp.API.Models.PseudoSkus;

namespace SubscriptionApp.API.Data.LinqToSql
{
    //Sample using LINQ to SQL
     public class PseudoSkuTitleRepository : Repository<PseudoSkuTitle, int>,
                                                           IPseudoSkuTitleRepository
    {
        public PseudoSkuTitleRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }
}