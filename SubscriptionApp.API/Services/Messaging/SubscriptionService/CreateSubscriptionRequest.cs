using System.Collections.Generic;

namespace SubscriptionApp.API.Services.Messaging.SubscriptionService
{
    public class CreateSubscriptionRequest
    {
        public CreateSubscriptionRequest()
        {
            PseudoSkusToAdd = new List<int>();
        }

        public IList<int> PseudoSkusToAdd { get; set; }
    }
}