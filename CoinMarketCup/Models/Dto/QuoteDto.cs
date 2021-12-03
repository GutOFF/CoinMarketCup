using Newtonsoft.Json;
using System;

namespace CoinMarketCup.Models.Dto
{
    public class QuoteDto
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("volume_24h")]
        public decimal VolumeDay { get; set; }

        [JsonProperty("percent_change_1h")]
        public decimal PercentChangeHour { get; set; }

        [JsonProperty("percent_change_24h")]
        public decimal PercentChangeDay { get; set; }

        [JsonProperty("market_cap")]
        public decimal MarketCap { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }
    }
}
