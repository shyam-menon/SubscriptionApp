using System.Collections.Generic;

namespace SubscriptionApp.API.Services.Messaging.SubscriptionService
{
    public class ModifySubscriptionRequest
    {
        public ModifySubscriptionRequest()
        {
            ItemsToRemove = new List<int>();
            PseudoSkusToAdd = new List<int>();
            ItemsToUpdate = new List<PseudoSkuQuantityUpdateRequest>();
        }

        public int SubscriptionId { get; set; }
        public IList<int> ItemsToRemove { get; set; }
        public IList<PseudoSkuQuantityUpdateRequest> ItemsToUpdate { get; set; }        
        public IList<int> PseudoSkusToAdd { get; set; }
    }        
}