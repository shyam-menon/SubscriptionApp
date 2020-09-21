using SubscriptionApp.API.Infrastructure.Domain;
using SubscriptionApp.API.Models.PseudoSkus;

namespace SubscriptionApp.API.Models.Subscriptions
{
    public class SubscriptionItem : EntityBase<int>
    {
        private int _qty;

        private Subscription _subscription;

        public virtual PseudoSku PseudoSku{ get; set; }

         public SubscriptionItem()
        {
        }

        public SubscriptionItem(PseudoSku pseudoSku, Subscription subscription, int qty)
        {
             PseudoSku = pseudoSku;
            _subscription = subscription;
            _qty = qty;
        }

         public decimal LineTotal()
        {
            return PseudoSku.Price * Qty;
        }
        public int Qty { get { return _qty; } }        

        public Subscription Basket { get { return _subscription; } }

        public bool Contains(PseudoSku pseudoSku)
        {
            return PseudoSku == pseudoSku;
        }

         public void ChangeItemQtyTo(int qty)
        {
            _qty = qty;
        }
        public void IncreaseItemQtyBy(int qty)
        {
            _qty += qty;
        }


        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}