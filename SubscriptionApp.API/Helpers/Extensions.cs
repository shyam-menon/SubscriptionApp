using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SubscriptionApp.API.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
       
        public static decimal AchieveMargin(this decimal val, decimal marginPercentage)
        {
            //In case the margin specified is more than 100 then reduce it to less than 100
            if (marginPercentage >= 100)
                marginPercentage = 99.99m;

            return (val / ((100 - marginPercentage) / 100));
        }
    }
}