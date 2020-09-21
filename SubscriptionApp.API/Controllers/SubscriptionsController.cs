using System.Security.Claims;
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
            //compare id of the path to the users id that is being passed with the token
            if(id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            
            var subscription = await _subscriptionservice
                                .GetSubscription(
                                    new GetSubscriptionRequest{SubscriptionId = id});

            if(subscription == null)
                return NotFound();


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