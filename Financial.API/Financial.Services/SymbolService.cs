using Financial.Data;
using Financial.Data.Models;
using Financial.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Services
{
    public class SymbolService : ISymbolService
    {
        private readonly FinancialDbContext _financialDbContext;
        public SymbolService(FinancialDbContext financialDbContext)
        {
            _financialDbContext = financialDbContext;
        }
        public async Task<List<Symbol>> GetSymbolsAsync()
        {
            return await _financialDbContext.Symbols.ToListAsync();
        }
    }
}
