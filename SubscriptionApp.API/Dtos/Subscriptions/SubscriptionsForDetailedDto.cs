using System;

namespace SubscriptionApp.API.Dtos.Subscriptions
{
    public class SubscriptionsForDetailedDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateSubscribed { get; set; }
    }
}