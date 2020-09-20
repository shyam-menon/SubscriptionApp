using System;
using SubscriptionApp.API.Infrastructure.Domain;

namespace SubscriptionApp.API.Models.PseudoSkus
{
    public class PseudoSkuColor: EntityBase<int>, IPseudoSkuAttribute
    {
         public string Name { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }     
    }
}