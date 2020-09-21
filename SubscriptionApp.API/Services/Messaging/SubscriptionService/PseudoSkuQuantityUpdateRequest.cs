namespace SubscriptionApp.API.Services.Messaging.SubscriptionService
{
    public class PseudoSkuQuantityUpdateRequest
    {
        public int PseudoSkuId { get; set; }
        public int NewQty { get; set; }
    }
}