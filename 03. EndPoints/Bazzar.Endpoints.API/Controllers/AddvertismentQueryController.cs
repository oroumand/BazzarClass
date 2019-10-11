using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.Advertisements.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bazzar.EndPoints.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddvertismentQueryController : ControllerBase
    {
        private readonly IAdvertisementQueryService advertisementQueryService;

        public AddvertismentQueryController(IAdvertisementQueryService advertisementQueryService)
        {
            this.advertisementQueryService = advertisementQueryService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]GetActiveAdvertisement request)
        {
            return new OkObjectResult(advertisementQueryService.Query(request));
        }

        //[HttpGet]
        //public IActionResult Get([FromQuery]GetActiveAdvertisementList request)
        //{
        //    return new OkObjectResult(advertisementQueryService.Query(request));
        //}
    }
}
