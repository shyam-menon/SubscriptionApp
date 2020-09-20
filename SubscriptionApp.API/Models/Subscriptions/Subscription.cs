using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SubscriptionApp.API.Models.PseudoSkus;

namespace SubscriptionApp.API.Models.Subscriptions
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateSubscribed { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public virtual decimal SubscriptionPrice { get; set; }
         public virtual ICollection<PseudoSku> PseudoSkus{ get; set; }
    }
}