using Microsoft.EntityFrameworkCore;
using SubscriptionApp.API.Models;

namespace SubscriptionApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

            //The properties here decides the name of the tables that will be created
            public DbSet<Value> Values { get; set; }
        
    }
}