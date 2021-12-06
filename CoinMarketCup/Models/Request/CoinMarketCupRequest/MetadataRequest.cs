using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinMarketCup.Models.Request.CoinMarketCupRequest
{
    public class MetadataRequest
    {
        public StatusRequest Status { get; set; }
        public Dictionary<string, CryptoCurrencyMetadataRequest> Data { get; set; }
    }
}
