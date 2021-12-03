using CoinMarketCup.Models.Dto;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using CoinMarketCup.Helpers;

namespace CoinMarketCup.Service
{
    public class CoinMarketCupService
    {
        private readonly CoinMarketCupHelpers _coinMarketCupHelpers;

        public CoinMarketCupService(CoinMarketCupHelpers coinMarketCupHelpers)
        {
            _coinMarketCupHelpers = coinMarketCupHelpers;
        }

        public async Task GetInformationQuotes()
        {
            var informationCryptoCurrencyListing = await _coinMarketCupHelpers.GetCryptoCurrencyListing(new ParametersListingLatesDto() {Start = 1});

        }
    }
}
