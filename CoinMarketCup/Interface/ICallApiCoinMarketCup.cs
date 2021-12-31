using CoinMarketCup.Models.Request.CoinMarketCupRequest;
using System.Threading.Tasks;

namespace CoinMarketCup.Interface
{
    public interface ICallApiCoinMarketCup
    {
        Task<ListingLatestRequest> GetCryptoCurrencyListing();
        Task<MetadataRequest> GetCryptoCurrencyMetadata(string id);
    }
}
