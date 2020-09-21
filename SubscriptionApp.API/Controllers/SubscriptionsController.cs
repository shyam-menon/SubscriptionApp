using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubscriptionApp.API.Services.Interfaces.SubscriptionService;
using SubscriptionApp.API.Services.Messaging.SubscriptionService;

namespace SubscriptionApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionservice;
        public SubscriptionsController(ISubscriptionService subscriptionservice)
        {
            _subscriptionservice = subscriptionservice;

        }

        //Get a subscription
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscriptions(int id)
        {
            var subscription = await _subscriptionservice
                                .GetSubscription(
                                    new GetSubscriptionRequest{SubscriptionId = id});

            return Ok(subscription);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
            //Call subscription service create
        }

     
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //Call subscription service modify
        }
    }
}