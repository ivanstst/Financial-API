using Financial.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Services.Interfaces
{
    public interface ISymbolService
    {
        Task<List<Symbol>> GetSymbolsAsync();
    }
}
