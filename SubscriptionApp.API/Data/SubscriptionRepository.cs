using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SubscriptionApp.API.Models.Subscriptions;

namespace SubscriptionApp.API.Data
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
         private readonly DataContext _context;
        public SubscriptionRepository(DataContext context)
        {
             _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
           _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }       

        public async Task<Subscription> FindBy(int id)
        {
            var subscription = await _context.Subscriptions.Include(s => s.SubscriptionItems).ToListAsync();
            return subscription.Find(s => s.Id == id);
        }
    }
}