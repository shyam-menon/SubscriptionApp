using SubscriptionApp.API.Helpers;

namespace SubscriptionApp.API.Models.PartnerSettings
{
    public class PseudoSkuPlanSettings
    {
        public int PageRangeStart { get; set; }
        public int PageRangeEnd { get; set; }
        public int MonthlyPages { get { return (PageRangeEnd - PageRangeStart);}}
        public decimal ResellerBuyPrice { get; set; }
        public decimal UseplanCpp { get {return (ResellerBuyPrice/MonthlyPages);}}
        public decimal OverageCpp { get; set; }
        public decimal ResellerMargin { get; set; }
        public decimal CustomerBuyPrice { get {return ResellerBuyPrice.AchieveMargin(ResellerMargin);}}
        public decimal  CustomerUsePlanCpp { get {return UseplanCpp.AchieveMargin(ResellerMargin);} }
        public decimal CustomerOverageCpp { get {return UseplanCpp.AchieveMargin(ResellerMargin);} }
        public int TippingPointToNextPlan { get; set; }
        public int EndCustomerCostAtTippingPoint { get; set; }
    }
}