using System.Collections.Generic;

namespace SubscriptionApp.API.Dtos.Subscriptions
{
    public class SubscriptionView
    {
        public SubscriptionView()
        {
            Items = new List<SubscriptionItemView>();
        }
        public int Id { get; set; }
        public string ItemsTotal { get; set; }
        public int NumberOfItems { get; set; }
        public IEnumerable<SubscriptionItemView> Items { get; set; }
        public string SubscriptionTotal { get; set; }
        
    }    
}