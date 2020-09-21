namespace SubscriptionApp.API.Dtos.Subscriptions
{
    public class SubscriptionItemView
    {
         public int Id { get; set; }
        public int PseudoSkuId { get; set; }
        public string PseudoSkuName { get; set; }
        public string PseudoSkuSizeName { get; set; }
        public int PseudoSkuTitleId { get; set; }
        public int Qty { get; set; }
        public string PseudoSkuPrice { get; set; }
        public string LineTotal { get; set; }
    }
}