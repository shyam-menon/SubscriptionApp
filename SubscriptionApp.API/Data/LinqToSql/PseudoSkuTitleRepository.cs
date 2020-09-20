using System.Collections.Generic;
using System.Threading.Tasks;
using SubscriptionApp.API.Infrastructure.Querying;
using SubscriptionApp.API.Infrastructure.UnitOfWork;
using SubscriptionApp.API.Models.PseudoSkus;

namespace SubscriptionApp.API.Data.LinqToSql
{
    //Sample using LINQ to SQL
     public class PseudoSkuTitleRepository : RepositoryLToS<PseudoSkuTitle, int>,
                                                           IPseudoSkuTitleRepository
    {
        public PseudoSkuTitleRepository(IUnitOfWork uow)
            : base(uow)
        {
        }

        public async Task<IEnumerable<PseudoSkuTitle>> FindByAsync(Query query, int index, int count)
        {
           return GenerateDummyPseudoSkus();
        }

        private List<PseudoSkuTitle> GenerateDummyPseudoSkus()
        {
             //Mock implemenation of repository. In reality this method only needed if the base
            //class repository implementation is not sufficient
            var pseudoSkuTitleList = new List<PseudoSkuTitle>
                                {
                                    new PseudoSkuTitle {
                                        Id = 1,
                                        Name = "A2W75A01",
                                        Model = new PseudoSkuModel { Name = "A2W75A"},
                                        Category = new Models.Categories.Category("Printer"),
                                        Color = new PseudoSkuColor { Name = "Color"},
                                        Function = new PseudoSkuFunction { Name = "PrintScanCopy"},
                                        Size = new PseudoSkuSize { Name = "A3"},
                                        Price = 100,
                                        //Multiple psedo skus can exist under a single plan (pseudo sku title)
                                        PseudoSkus = new List<PseudoSku>
                                        {
                                            {new PseudoSku{}},
                                            {new PseudoSku{}},
                                            {new PseudoSku{}}
                                        }
                                    }
                                };
                return pseudoSkuTitleList;
        }
    }
}