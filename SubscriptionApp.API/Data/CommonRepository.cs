using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SubscriptionApp.API.Models;

namespace SubscriptionApp.API.Data
{
    public class CommonRepository : IGenericRepository, IUserRepository
    {
        private readonly DataContext _context;
        public CommonRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            //This need not be async as when this is done there is no DB action
            // and is kept in memory
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            //Same as add. No need of async
            _context.Remove(entity);
        }

        //For async methods in ADO.Net see below link
        //https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/asynchronous-programming#:~:text=When%20calling%20an%20async%20method,resumes%20in%20the%20same%20method.&text=Asynchronous%20calls%20are%20not%20supported,Context%20Connection%20connection%20string%20keyword.
        public async Task<User> GetUser(int id)
        {
            //Let EF know that navigation property needs to be included
            var user = await _context.Users.Include(s => s.Subscriptions).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(s => s.Subscriptions).ToListAsync();
            return users;
        }

        public async Task<bool> SaveAll()
        {
            //Save successfully will result in SaveChangesAsync returning value > 0
            return await _context.SaveChangesAsync() > 0;
        }
    }
}