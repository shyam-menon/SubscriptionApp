using Microsoft.EntityFrameworkCore;
using SubscriptionApp.API.Models;
using SubscriptionApp.API.Models.Categories;
using SubscriptionApp.API.Models.PseudoSkus;
using SubscriptionApp.API.Models.Subscriptions;

namespace SubscriptionApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

            //The properties here decides the name of the tables that will be created
            public DbSet<Value> Values { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Subscription> Subscriptions { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<PseudoSkuTitle> PseudoSkuTitles { get; set; }
            public DbSet<PseudoSku> PseudoSkus { get; set; }
            public DbSet<PseudoSkuModel> PseudoSkuModels { get; set; }

            public DbSet<PseudoSkuColor> PseudoSkuColors { get; set; }
            public DbSet<PseudoSkuFunction> PseudoSkuFunctions { get; set; }
            public DbSet<PseudoSkuSize> PseudoSkuSize { get; set; }
        
    }
}