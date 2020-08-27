using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubscriptionApp.API.Data;

namespace SubscriptionApp.API.Controllers
{
    [Authorize]
    //Authorize requests to the controller. Works only after login
    [Route("api/[controller]")]
    //Forces attribute routing and automatically validates request. The routing is done to the
    //based on the name of the controller /api/Values in this case as this is ValuesController
    [ApiController]
    //inherits from controller base which gives access to HTTP responses which is what is
    //used by IActionResult in the controller actions.
    //When inherited from Controller instead of ControllerBase, then the base will be an
    //an MVC controller with view support unliker Controller which has no view support which is what
    //is needed when out UI is in Angular
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;

        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();

            return Ok(values);
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }

        // POST api/values        
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
