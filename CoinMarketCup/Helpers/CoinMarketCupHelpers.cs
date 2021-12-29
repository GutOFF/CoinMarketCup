using CoinMarketCup.Models.Request.CoinMarketCupRequest;
using Entity.Model;
using System.Collections.Generic;
using System.Linq;

namespace CoinMarketCup.Helpers
{
    public static class CoinMarketCupHelpers
    {
        public static MetadataRequest MetadataListToMetadata(IReadOnlyCollection<MetadataRequest> metadataRequests)
        {
            var metadataRequestResult = new MetadataRequest()
            {
                Data = new Dictionary<string, CryptoCurrencyMetadataRequest>(),
                Status = metadataRequests.LastOrDefault()?.Status
            };

            foreach (var (id, cryptoCurrencyMetadata) in metadataRequests.SelectMany(metadataRequest => metadataRequest.Data))
            {
                metadataRequestResult
                    .Data
                    .Add(id, cryptoCurrencyMetadata);
            }

            return metadataRequestResult;
        }

        public static List<Cryptocurrency> ObjectShapingCryptocurrencies(ListingLatestRequest listingLatestRequest, MetadataRequest metadataRequest, string fiatValue)
        {
            return listingLatestRequest.Data.Select(item => new Cryptocurrency()
                {
                    CoinMarketCupId = item.Id,
                    Name = item.Name,
                    Symbol = item.Symbol,
                    Logo = metadataRequest?.Data[item.Id.ToString()]?.Logo,
                    LastUpdated = item.Quote[fiatValue].LastUpdated,
                    MarketCap = item.Quote[fiatValue].MarketCap,
                    PercentChange1H = item.Quote[fiatValue].PercentChange1H,
                    PercentChange24H = item.Quote[fiatValue].PercentChange24H,
                    Price = item.Quote[fiatValue].Price
                })
                .ToList();
        }
    }
}
