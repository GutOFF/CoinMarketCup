using Newtonsoft.Json;
using System.Collections.Generic;

namespace CoinMarketCup.Models.Request.CoinMarketCupRequest
{
    public class CryptoCurrencyListingRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("quote")]
        public Dictionary<string, QuoteRequest> Quote { get; set; }
    }
}
