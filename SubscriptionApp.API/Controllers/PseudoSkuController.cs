using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubscriptionApp.API.Dtos.PseudoSkus;
using SubscriptionApp.API.Services.Interfaces.PseudoSkuCatalogService;

namespace SubscriptionApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PseudoSkuController : ControllerBase
    {
        private readonly IPseudoSkuCatalogService _pseudoSkuCatalogService;
        private readonly IMapper _mapper;
        public PseudoSkuController(IPseudoSkuCatalogService pseudoSkuCatalogService, IMapper mapper)
        {
            _mapper = mapper;
            _pseudoSkuCatalogService = pseudoSkuCatalogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPseudoSkus()
        {
            var pseudoSkusToReturn = await _pseudoSkuCatalogService.GetAllPseudoSkus();           

            return Ok(pseudoSkusToReturn);
        }
    }
}