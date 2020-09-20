using System.Collections.Generic;
using SubscriptionApp.API.Dtos.Subscriptions;
using SubscriptionApp.API.Models;

namespace SubscriptionApp.API.Dtos
{
    public class UserForDetailedDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Country { get; set; }
        public ICollection<SubscriptionsForDetailedDto> Subscriptions { get; set; }
    }
}