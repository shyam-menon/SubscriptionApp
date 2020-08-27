using System;

namespace SubscriptionApp.API.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateSubscribed { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public decimal SubscriptionPrice { get; set; }
    }
}