using System.Collections.Generic;

namespace CoinMarketCup.Models.Request.CoinMarketCupRequest
{
    public class ListingLatestRequest
    {
        public StatusRequest Status { get; set; }
        public List<CryptoCurrencyListingRequest> Data { get; set; }
    }
}
