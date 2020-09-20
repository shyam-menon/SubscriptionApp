using SubscriptionApp.API.Infrastructure.Domain;

namespace SubscriptionApp.API.Models.Categories
{
     public interface ICategoryRepository : IReadOnlyRepository<Category,int>
    {
    }
}