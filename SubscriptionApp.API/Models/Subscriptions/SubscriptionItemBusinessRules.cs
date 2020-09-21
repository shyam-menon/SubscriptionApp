using SubscriptionApp.API.Infrastructure.Domain;

namespace SubscriptionApp.API.Models.Subscriptions
{
    public class SubscriptionItemBusinessRules
    {
         public static readonly BusinessRule SubscriptionRequired =
            new BusinessRule("Subscription", "A subscription item must be related to a subscription.");
        public static readonly BusinessRule PseudoSkuRequired =
            new BusinessRule("PseudoSku", "A subscription item must be related to a pseudo SKU.");
        public static readonly BusinessRule QtyInvalid =
            new BusinessRule("Qty", "The quantity of a subscription item cannot be negative.");
    }
}