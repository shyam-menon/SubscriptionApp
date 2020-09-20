using System;
using SubscriptionApp.API.Infrastructure.Domain;

namespace SubscriptionApp.API.Models.PseudoSkus
{
    //Equivalent to brand
    public class PseudoSkuModel : EntityBase<int>, IPseudoSkuAttribute
    {
         public string Name { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}