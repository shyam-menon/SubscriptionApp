using SubscriptionApp.API.Infrastructure.Domain;

namespace SubscriptionApp.API.Models.Subscriptions
{
    public class SubscriptionBusinessRules
    {
        public static readonly BusinessRule SalesModeRequired =
                    new BusinessRule("SalesMode",
                                        "A subscription must have a sales mode");
        public static readonly BusinessRule ContractTermRequired =
                    new BusinessRule("ContractTerm",
                                        "A subscription must have a contract term of a least 12 months");
        public static readonly BusinessRule ItemInvalid =
                    new BusinessRule("Item", "A subscription cannot have any invalid items.");
    }
}