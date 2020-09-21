using SubscriptionApp.API.Models.PseudoSkus;

namespace SubscriptionApp.API.Models.Subscriptions
{
    public class SubscriptionItemFactory
    {
        public static SubscriptionItem CreateItemFor(PseudoSku pseudoSku, Subscription subscription)
        {
            return new SubscriptionItem(pseudoSku, subscription, 1);
        }
    }
}