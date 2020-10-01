using System.Collections.Generic;
using SubscriptionApp.API.Models.Common;

namespace SubscriptionApp.API.Models.PartnerSettings
{
    public class SmpsPartnerSettings
    {
        public Partner Partner { get; set; }
        public Country PartnerCountry { get; set; }
        public IEnumerable<string> AvailableProgramSalesModes { get; set; }
        public string DefaultProgramSalesMode { get; set; }
        public bool IsEagreementNeeded { get; set; }
        public IEnumerable<ResellFamilySettings> ResellSettings { get; set; }
        public IEnumerable<AgentFamilySettings> AgentSettings { get; set; }
    }
}