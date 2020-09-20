using System;
using SubscriptionApp.API.Infrastructure.Domain;

namespace SubscriptionApp.API.Models.PseudoSkus
{
    //Equivalent to category
    public class PseudoSkuFunction: EntityBase<int>, IPseudoSkuAttribute
    {
         public string Name { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}