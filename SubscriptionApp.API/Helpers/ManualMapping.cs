using System.Collections.Generic;
using SubscriptionApp.API.Dtos.Subscriptions;
using SubscriptionApp.API.Models.Subscriptions;

namespace SubscriptionApp.API.Helpers
{
    public static class ManualMapping
    {
        public static void MapPseudoSkus(this SubscriptionView view, Subscription subscription)
        {
            if(subscription.SubscriptionItems == null)
                return;           
           
                
           foreach (var subscriptionItem in subscription.SubscriptionItems)
           {
               if(subscriptionItem.PseudoSku == null)
                continue;
                
               view.Items = new List<SubscriptionItemView>();               
               view.Items.Add(new SubscriptionItemView
               {
                   PseudoSkuId = subscriptionItem.PseudoSku.Id,
                   PseudoSkuName = subscriptionItem.PseudoSku.Name,
                   PseudoSkuSizeName = subscriptionItem.PseudoSku.Size.Name
               });
           }
        }
    }
}
           
        
    
