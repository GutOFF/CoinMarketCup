using CoinMarketCup.Helpers;
using CoinMarketCup.Models.Request.CoinMarketCupRequest;
using CoinMarketCup.Repository;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace CoinMarketCup.API
{
    public class CallCoinMarketCup
    {
        private readonly SettingCryptocurrencyRepository _settingCryptocurrencyRepository;
        public CallCoinMarketCup(SettingCryptocurrencyRepository settingCryptocurrencyRepository)
        {
            _settingCryptocurrencyRepository = settingCryptocurrencyRepository;
        }

        public async Task<ListingLatestRequest> GetCryptoCurrencyListing()
        {
            var url = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString["limit"] = (await _settingCryptocurrencyRepository.GetLimit()).ToString();

            url.Query = queryString.ToString() ?? string.Empty;

            var stringJson = await Call(url);

            var deserializeDate = new DeserializeData<ListingLatestRequest>();

            return deserializeDate.Deserialize(stringJson);
        }

        public async Task<MetadataRequest> GetCryptoCurrencyMetadata(string id)
        {
            var url = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/info");
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString["id"] = id;

            url.Query = queryString.ToString() ?? string.Empty;

            var stringJson = await Call(url);

            var deserializeDate = new DeserializeData<MetadataRequest>();
            return deserializeDate.Deserialize(stringJson);
        }

        private  async Task<string> Call(UriBuilder urlBuilder)
        {
            using HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders
                .Add("X-CMC_PRO_API_KEY", await _settingCryptocurrencyRepository.GetApiKey());

            httpClient.BaseAddress = urlBuilder.Uri;
            var stringJson = await httpClient.GetStringAsync(urlBuilder.ToString());
            return stringJson;
        }

      
    }
}
