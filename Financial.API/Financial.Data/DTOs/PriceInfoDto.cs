using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Text.Json.Serialization;
using Newtonsoft.Json;

using System.Threading.Tasks;

namespace Financial.Data.DTOs
{
    public class PriceInfoDto
    {
        [JsonProperty("mins")]
        public int AveragePriceInMinutes { get; set; }
        [JsonProperty("price")]
        public decimal AveragePrice { get; set; }
        public long CloseTime { get; set; }
    }
}
