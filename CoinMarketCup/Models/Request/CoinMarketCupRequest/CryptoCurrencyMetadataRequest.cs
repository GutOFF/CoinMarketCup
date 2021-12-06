using Newtonsoft.Json;

namespace CoinMarketCup.Models.Request.CoinMarketCupRequest
{
    public class CryptoCurrencyMetadataRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

    }
}
