using System;
using Newtonsoft.Json;

namespace CoinMarketCup.Models.Request.CoinMarketCupRequest
{
    public class QuoteRequest
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("percent_change_1h")]
        public decimal PercentChange1H { get; set; }

        [JsonProperty("percent_change_24h")]
        public decimal PercentChange24H { get; set; }

        [JsonProperty("market_cap")]
        public decimal MarketCap { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }
    }
}
