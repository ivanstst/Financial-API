using Financial.Data;
using Financial.Data.Models;
using Financial.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Financial.Services
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private FinancialDbContext dbContext;
        public DatabaseInitializer(FinancialDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Initialize()
        {
            var test = dbContext;
            await this.dbContext.Database.MigrateAsync();
            await this.Seed();
        }
        private async Task Seed()
        {
            var existingSymbols = this.dbContext.Symbols.Count();
            if (existingSymbols == 0)
            {
                var symbols = new List<Symbol>
                {
                    new Symbol("BTCUSDT"),
                    new Symbol("ETCUSDT"),
                    new Symbol("XRPUSDT")
                };
                this.dbContext.Symbols.AddRange(symbols);
                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}
