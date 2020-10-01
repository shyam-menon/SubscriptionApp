using SubscriptionApp.API.Infrastructure.Domain;

namespace SubscriptionApp.API.Models.Common
{
    public class Partner : EntityBase<int>, IAggregateRoot
    {
        public string Name { get; set; }
        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}