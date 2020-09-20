using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SubscriptionApp.API.Infrastructure.Domain;
using SubscriptionApp.API.Models.Categories;

namespace SubscriptionApp.API.Models.PseudoSkus
{
    //Represents the name of a PseudoSkuTitle, and a PseudoSku has a number of attributes, 
    //such as a Model, Mono vs Color, Single vs Multi function, Size (A3 vs A4) and Category

    public class PseudoSkuTitle : IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public virtual PseudoSkuModel Model { get; set; }
         public virtual Category Category { get; set; }
        public virtual PseudoSkuColor Color { get; set; }
        public virtual PseudoSkuFunction Function { get; set; }        
        public virtual PseudoSkuSize Size { get; set; }
        public virtual IEnumerable<PseudoSku> PseudoSkus { get; set; }
    }
}