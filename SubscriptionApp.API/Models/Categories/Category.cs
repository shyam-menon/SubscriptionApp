using System;
using SubscriptionApp.API.Infrastructure.Domain;
using SubscriptionApp.API.Models.PseudoSkus;

namespace SubscriptionApp.API.Models.Categories
{
    public class Category : EntityBase<int>, IAggregateRoot, IPseudoSkuAttribute
    {
        public Category(string name)
        {
            this.Name = name;

        }
        public string Name { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}