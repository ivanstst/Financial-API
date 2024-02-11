using Financial.Data.Models;
using Financial.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SymbolsController : ControllerBase
    {
        private readonly ISymbolService _symbolService;

        public SymbolsController(ISymbolService symbolService)
        {
            _symbolService = symbolService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Symbol>>> GetSymbols()
        {
            var symbols = await _symbolService.GetSymbolsAsync();
            if (symbols == null)
            {
                return NotFound();
            }
            return symbols;
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Symbol>> GetSymbol(int id)
        //{
        //    var symbol = await _symbolService.GetSymbolAsync(id);
        //    if (symbol == null)
        //    {
        //        return NotFound();
        //    }

        //    return symbol;
        //}
    }
}
