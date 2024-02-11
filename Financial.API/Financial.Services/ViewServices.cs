using Financial.Data;
using Financial.Data.Models;
using Financial.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Financial.Services
{
    public class ViewServices : IViewService
    {
        private readonly FinancialDbContext _financialDbContext;
        public ViewServices(FinancialDbContext financialDbContext)
        {
            _financialDbContext = financialDbContext;
        }
        public async Task CreateViewAsync(View view)
        {
            _financialDbContext.Views.Add(view);
            await _financialDbContext.SaveChangesAsync();
        }

        public async Task DeleteViewAsync(int viewId)
        {
            var view = _financialDbContext.Views.FirstOrDefault(x => x.Id == viewId);
            _financialDbContext.Views.Remove(view);
            await _financialDbContext.SaveChangesAsync();
        }

        public async Task<View?> GetViewAsync(int viewId, int userId)
        {
            return await _financialDbContext.Views.FirstOrDefaultAsync(x => x.Id == viewId && x.UserId == userId);
        }

        public async Task<List<View>> GetViewsAsync(int userId)
        {
            return await _financialDbContext.Views.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
