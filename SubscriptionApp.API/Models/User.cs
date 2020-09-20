using System.Collections.Generic;
using SubscriptionApp.API.Models.Subscriptions;

namespace SubscriptionApp.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public string Country { get; set; }
        public virtual ICollection<Subscription> Subscriptions{ get; set; }
    }
}