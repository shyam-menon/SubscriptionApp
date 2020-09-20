using SubscriptionApp.API.Infrastructure.UnitOfWork;
using SubscriptionApp.API.Models.Categories;

namespace SubscriptionApp.API.Data.LinqToDto
{
    //Sample using LINQ to DTO
     public class CategoryRepository : RepositoryLToD<Category, int>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }
}