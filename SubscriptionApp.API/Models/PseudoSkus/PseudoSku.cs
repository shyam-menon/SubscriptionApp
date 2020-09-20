using System;
using SubscriptionApp.API.Infrastructure.Domain;
using SubscriptionApp.API.Models.Categories;

namespace SubscriptionApp.API.Models.PseudoSkus
{
    //A PseudoSku represents the Sku a user can add to the subscription 
    // and includes a PseudoSkuSize, PseudoSkuFunction etc as well as a reference to its
    //PseudoSkuTitle and some helper methods to quickly obtain access to the other attributes.
    public class PseudoSku : EntityBase<int>, IAggregateRoot
    {       

        public virtual PseudoSkuTitle Title { get; set; }

        public string Name
        {
            get { return Title.Name; }
        }

        public Decimal Price
        {
            get { return Title.Price; }
        }

        public virtual PseudoSkuModel Model
        {
            get { return Title.Model; }
        }

        public virtual PseudoSkuColor Color
        {
            get { return Title.Color; }
        }

        public virtual  PseudoSkuFunction Function
        {
            get { return Title.Function; }
        }

        public virtual  PseudoSkuSize Size
        {
            get { return Title.Size; }
        }

        public virtual  Category Category
        {
            get { return Title.Category; }
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }    
}