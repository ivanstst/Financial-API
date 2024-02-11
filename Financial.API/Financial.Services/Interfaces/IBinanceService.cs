using Financial.Data.DTOs;

namespace Financial.Services.Interfaces
{
    public interface IBinanceService
    {
        Task<IEnumerable<KlineDTO>> GetDataPointsAsync(string symbol, string interval);
        Task<decimal> GetAveragePriceAsync(string symbol);
    }
}
