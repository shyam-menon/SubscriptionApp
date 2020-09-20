using SubscriptionApp.API.Infrastructure.Domain;
using SubscriptionApp.API.Infrastructure.UnitOfWork;
using SubscriptionApp.API.Models.PseudoSkus;

namespace SubscriptionApp.API.Data.LinqToSql
{
    public class PseudoSkuRepository: Repository<PseudoSku, int>,
                                                           IPseudoSkuRepository
    {
        public PseudoSkuRepository(IUnitOfWork uow)
            : base(uow)
        {
        }        
    }
}