using System.Collections.Generic;

namespace CoinMarketCup.Models.Request.CoinMarketCupRequest
{
    public class MetadataRequest
    {
        public StatusRequest Status { get; set; }
        public Dictionary<string, CryptoCurrencyMetadataRequest> Data { get; set; }

    }
}
