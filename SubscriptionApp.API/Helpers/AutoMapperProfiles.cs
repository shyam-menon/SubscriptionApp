using AutoMapper;
using SubscriptionApp.API.Dtos;
using SubscriptionApp.API.Models;

namespace SubscriptionApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        //Convention based mapping based on property name
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailedDto>();
            CreateMap<Subscription, SubscriptionsForDetailedDto>();
        }
    }
}