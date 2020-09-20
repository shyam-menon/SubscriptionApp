using System.Collections.Generic;

namespace SubscriptionApp.API.Dtos.PseudoSkus
{
    public class PseudoSkuView
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public IEnumerable<PseudoSkuSizeOption> Products { get; set; }
    }
}