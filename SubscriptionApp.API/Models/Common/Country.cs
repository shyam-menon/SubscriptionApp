using SubscriptionApp.API.Infrastructure.Domain;

namespace SubscriptionApp.API.Models.Common
{
    public class Country : EntityBase<int>
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string CurrencyAbbreviation { get; set; }
        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}