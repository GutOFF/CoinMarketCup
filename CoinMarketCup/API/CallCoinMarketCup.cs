using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using CoinMarketCup.Helpers;
using CoinMarketCup.Models.Request.CoinMarketCupRequest;

namespace CoinMarketCup.API
{
    public class CallCoinMarketCup
    {
        private static string API_KEY = "10c2408c-f3fd-4c1e-801e-b97ba3bba899";
        private const int Limit = 5;

        public async Task<ListingLatestRequest> GetCryptoCurrencyListing()
        {
            var url = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString["limit"] = Limit.ToString();

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

        private async Task<string> Call(UriBuilder urlBuilder)
        {
            using HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders
                .Add("X-CMC_PRO_API_KEY", API_KEY);

            httpClient.BaseAddress = urlBuilder.Uri;
            var stringJson = await httpClient.GetStringAsync(urlBuilder.ToString());
            return stringJson;
        }

    }
}
