using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SubscriptionApp.API.Data;
using SubscriptionApp.API.Dtos;
using SubscriptionApp.API.Models;

namespace SubscriptionApp.API.Controllers
{
    [Route("api/[controller]")]
    //Without the APIController attribute, ASP.Net core cannot infer from the request to map to DTO and "FromBody" will be needed
    //Also the validation of the the request within the DTO will not happen and will need use of  "!ModelState.IsValid" in the action
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;

            //This is to get the value from appsettings.json
            _config = config;

        }
        

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _repo.UserExists(userForRegisterDto.Username))
                //BadRequest needs inheritance from controller base
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            //Before attempting to login, check whether the user exists in the DB
            var userFromRepo = await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            //When username does not exist then return unauthorized
            if (userFromRepo == null)
                return Unauthorized();

            //Build the JWT token and with this token, the server need not go to the database to check
            //its validity and this is reduces the overhead of each API call of doing an I/O to the DB.
            
            //The (1)claims in the token need to enable this and in this case will have 2 claims
            var claims = new[]
            {
                //For ID
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                //For User name
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            //The token needs to be validated with each request to the server.
            //Create key based on token in the appsetting.json file.
            //Server uses this secret key to ensure the signature of the token and so this needs
            //to be stored safely in production
            var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_config.GetSection("AppSettings:Token").Value));

            //The (2)signing credentials combines the security key generated from the token and uses an algorithm
            //we choose to hash the key
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //Create token descriptor that will contain (1)claims, expiry date (24 hours) for the token and
            //(2)signing credentials
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            //Create a JWT token handler
            var tokenHandler = new JwtSecurityTokenHandler();

            //Using token handler, a token can be created passing the token descriptor
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            //Return token as object in the response
            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });
        }


    }
}