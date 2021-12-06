using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinMarketCup.Models.Request.CoinMarketCupRequest;

namespace CoinMarketCup.Models.Dto
{
    public class CryptoDto
    {
        public ListingLatestRequest ListingLatestRequest { get; set; }
        public MetadataRequest MetadataRequest { get; set; }
    }
}
