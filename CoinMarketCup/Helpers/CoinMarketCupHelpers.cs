using CoinMarketCup.Models.Dto;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace CoinMarketCup.Helpers
{
    public class CoinMarketCupHelpers
    {
        private static string API_KEY = "10c2408c-f3fd-4c1e-801e-b97ba3bba899";
        private static readonly HttpClient HttpClient;
        static CoinMarketCupHelpers()
        {
            HttpClient = new HttpClient();
        }

        public async Task<string> GetCryptoCurrencyListing(ParametersListingLatesDto parameters)
        {
            var url = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString["start"] = parameters.Start.ToString();

            url.Query = queryString.ToString() ?? string.Empty;
            HttpClient.BaseAddress = url.Uri;
            HttpClient.DefaultRequestHeaders
                .Add("X-CMC_PRO_API_KEY",API_KEY);
            HttpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await HttpClient.GetAsync(url.Uri);
          
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();
            return resp;
        }

        public string GetCryptoCurrencyMetadata(string id)
        {
            var url = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/info");
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString["id"] = id;

            url.Query = queryString.ToString() ?? string.Empty;

            var client = new WebClient();
            client.Headers["X-CMC_PRO_API_KEY"] = API_KEY;
            client.Headers["Accepts"] = "application/json";
            return client.DownloadString(url.ToString());
        }


    }
}
