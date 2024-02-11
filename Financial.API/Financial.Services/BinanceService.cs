using Financial.Data.DTOs;
using Financial.Services.Interfaces;
using Newtonsoft.Json;
using System.Globalization;

namespace Financial.Services
{
    public class BinanceService : IBinanceService
    {
        private readonly HttpClient _httpClient;
        public BinanceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<KlineDTO>> GetDataPointsAsync(string symbol, string interval)
        {
            var response = await _httpClient.GetAsync($"https://api.binance.com/api/v3/klines?symbol={symbol}&interval={interval}&limit=20");

            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var dataPoints = TransformJson(stringResponse);
            return dataPoints;
        }

        public async Task<decimal> GetAveragePriceAsync(string symbol)
        {
            var response = await _httpClient.GetAsync($"https://api.binance.com/api/v3/avgPrice?symbol={symbol}");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var averagePrice = JsonConvert.DeserializeObject<PriceInfoDto>(stringResponse);

            return averagePrice.AveragePrice;
        }

        private List<KlineDTO> TransformJson(string json)
        {
            var rawData = JsonConvert.DeserializeObject<List<List<object>>>(json);

            var transformedData = rawData.Select(item => new KlineDTO
            {
                OpenTime = Convert.ToInt64(item[0]),
                OpenPrice = Convert.ToDecimal(item[1], CultureInfo.InvariantCulture)
            }).ToList();
            return transformedData;
        }

    }
}
