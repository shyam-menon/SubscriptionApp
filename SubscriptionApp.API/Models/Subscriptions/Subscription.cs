using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using SubscriptionApp.API.Infrastructure.Domain;
using SubscriptionApp.API.Models.PseudoSkus;

namespace SubscriptionApp.API.Models.Subscriptions
{
    public class Subscription : EntityBase<int>, IAggregateRoot
    {
        private IList<SubscriptionItem> _items;

        public virtual ICollection<SubscriptionItem> SubscriptionItems{ get; set; }

          public Subscription()
        {
            SubscriptionItems = new List<SubscriptionItem>(); 
            _items = SubscriptionItems.ToList();           
        }

         public int NumberOfItems
        {
            get { return _items.Sum(i => i.Qty); }
        }

        public decimal SubscriptionTotal
        {
            get { return ItemsTotal; }
        }

        public decimal ItemsTotal
        {
            get { return _items.Sum(i => i.Qty * i.PseudoSku.Price); }
        }

        public void Add(PseudoSku pseudoSku)
        {
            if (SubscriptionContainsAnItemFor(pseudoSku))
                GetItemFor(pseudoSku).IncreaseItemQtyBy(1);
            else
                _items.Add(SubscriptionItemFactory.CreateItemFor(pseudoSku, this));
        }

        public SubscriptionItem GetItemFor(PseudoSku pseudoSku)
        {
            return _items.Where(i => i.Contains(pseudoSku)).FirstOrDefault();
        }

        private bool SubscriptionContainsAnItemFor(PseudoSku pseudoSku)
        {
            return _items.Any(i => i.Contains(pseudoSku));
        }

        public void Remove(PseudoSku pseudoSku)
        {
            if (SubscriptionContainsAnItemFor(pseudoSku))
            {
                _items.Remove(GetItemFor(pseudoSku));
            }
        }

        public void ChangeQtyOfPseudoSku(int qty, PseudoSku pseudoSku)
        {
            if (SubscriptionContainsAnItemFor(pseudoSku))
            {
                GetItemFor(pseudoSku).ChangeItemQtyTo(qty);
            }
        }

        public int NumberOfItemsInSubscription()
        {
            return _items.Sum(i => i.Qty);
        }

         public IEnumerable<SubscriptionItem> Items()
        {
            return _items;
        }
        protected override void Validate()
        {
            foreach (SubscriptionItem item in this.Items())
            {
                if (item.GetBrokenRules().Count() < 0)
                    base.AddBrokenRule(SubscriptionBusinessRules.ItemInvalid);
            }
        }
    }
}