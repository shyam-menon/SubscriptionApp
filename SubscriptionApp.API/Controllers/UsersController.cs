using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubscriptionApp.API.Data;
using SubscriptionApp.API.Dtos;
using SubscriptionApp.API.Services;

namespace SubscriptionApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISubscriptionRepository _repo;
        private readonly IMapper _mapper;
        private readonly ISubscriptionService _subscriptionService;
        public UsersController(ISubscriptionRepository repo, IMapper mapper, ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();            

            //Map between the user model and the user DTO so that sensitive information is not 
            //passed back in the API response
            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);

            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);

            //Map between the user model and the user DTO so that sensitive information is not 
            //passed back in the API response
            var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            return Ok(userToReturn);
        }
    }
}