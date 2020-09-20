using AutoMapper;
using SubscriptionApp.API.Dtos;
using SubscriptionApp.API.Dtos.Categories;
using SubscriptionApp.API.Dtos.PseudoSkus;
using SubscriptionApp.API.Dtos.Refinements;
using SubscriptionApp.API.Dtos.Subscriptions;
using SubscriptionApp.API.Models;
using SubscriptionApp.API.Models.Categories;
using SubscriptionApp.API.Models.PseudoSkus;
using SubscriptionApp.API.Models.Subscriptions;

namespace SubscriptionApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        //Convention based mapping based on property name
        //Domain entities to View model mapping
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailedDto>();
            CreateMap<Subscription, SubscriptionsForDetailedDto>();

            // PseudoSkuse
            CreateMap<PseudoSkuTitle, PseudoSkuSummaryView>();
            CreateMap<PseudoSkuTitle, PseudoSkuView>();
            CreateMap<PseudoSku, PseudoSkuSummaryView>();
            CreateMap<PseudoSku, PseudoSkuSizeOption>();

            // Category
            CreateMap<Category, CategoryView>();

            // IProductAttribute
            CreateMap<IPseudoSkuAttribute, Refinement>();           
        }        
    }
     
}