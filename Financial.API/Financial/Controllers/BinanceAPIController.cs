using Financial.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Access")]
    public class BinanceAPIController : ControllerBase
    {

        private readonly IBinanceService _binanceService;

        public BinanceAPIController(IBinanceService binanceService)
        {
            _binanceService = binanceService;
        }

        [HttpGet("{symbol}/datapoints")]
        //[ValidateUserHeader]
        public async Task<IActionResult> GetDataPoints(string symbol, [FromQuery] string interval)
        {
            var dataPoints = await _binanceService.GetDataPointsAsync(symbol, interval);
            return Ok(dataPoints);
        }

        [HttpGet("{symbol}/average")]
        //[ValidateUserHeader]
        public async Task<IActionResult> GetAveragePrice(string symbol)
        {
            var averagePrice = await _binanceService.GetAveragePriceAsync(symbol);
            return Ok(averagePrice);
        }
    }
}
