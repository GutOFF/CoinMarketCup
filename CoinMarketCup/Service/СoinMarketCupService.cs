using CoinMarketCup.API;
using CoinMarketCup.Models;
using CoinMarketCup.Models.Request.CoinMarketCupRequest;
using CoinMarketCup.Monad;
using CoinMarketCup.Repository;
using Entity.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinMarketCup.Helpers;


namespace CoinMarketCup.Service
{
    public class CoinMarketCupService
    {
        private readonly CallCoinMarketCup _callCoinMarketCup;
        private readonly CoinMarketRepository _coinMarketRepository;
        private readonly SettingCryptocurrencyRepository _settingCryptocurrencyRepository;
        private readonly ILogger<CoinMarketCupService> _logger;


        public CoinMarketCupService(CallCoinMarketCup coinMarketCupHelpers, CoinMarketRepository coinMarketRepository, SettingCryptocurrencyRepository settingCryptocurrencyRepository, ILogger<CoinMarketCupService> logger)
        {
            _callCoinMarketCup = coinMarketCupHelpers;
            _coinMarketRepository = coinMarketRepository;
            _settingCryptocurrencyRepository = settingCryptocurrencyRepository;
            _logger = logger;
        }

        public async Task<Return<List<Cryptocurrency>>> GetOrCreateCryptocurrencies(PaginatorInfoModel paginatorInfo, SortState sortState)
        {
            _logger.LogInformation("Start get or create cryptocurrencies");

            if (await _coinMarketRepository.IsExpiryDateExpired())
            {
                var cryptocurrencies = await GetCryptocurrencies();
                
                if (!cryptocurrencies.IsSuccessfully)
                {
                    _logger.LogError("Error get cryptocurrencies");
                    return Return<List<Cryptocurrency>>.ReturnFail(cryptocurrencies.Error);
                }

                await _coinMarketRepository.DeleteAllDate();

                await DateRecord(cryptocurrencies.Information);
            }

            var result = await _coinMarketRepository.GetCryptocurrencies(paginatorInfo, sortState);

            return Return<List<Cryptocurrency>>.ReturnSuccessfully(result);

        }

        public async Task DateRecord(List<Cryptocurrency> cryptocurrencies)
        {
            await _coinMarketRepository.AddRange(cryptocurrencies);
        }

        public async Task<Return<List<Cryptocurrency>>> GetCryptocurrencies()
        {
            var listingLatestRequest = await GetListingLatest();

            if (!listingLatestRequest.IsSuccessfully)
            {
                _logger.LogError($"Listing latest is not successfully" +
                                 $"error message : {listingLatestRequest.Information.Status.ErrorMessage}");
                return Return<List<Cryptocurrency>>.ReturnFail(listingLatestRequest.Error);
            }

            var listId = await GetIdCoin(listingLatestRequest.Information);

            var metadataRequest = await GetMetadata(listId);
           
            string fiatValue = await _settingCryptocurrencyRepository.GetFiatCurrency();

            if (!metadataRequest.IsSuccessfully)
            {
                _logger.LogError($"Metadata is not successfully" +
                                 $"error message : {metadataRequest.Information.Status.ErrorMessage}");
                Return<List<Cryptocurrency>>.ReturnFail(listingLatestRequest.Error);
            }

            return Return<List<Cryptocurrency>>.ReturnSuccessfully(CoinMarketCupHelpers.ObjectShapingCryptocurrencies(listingLatestRequest.Information, metadataRequest.Information, fiatValue));
        }

        private async Task<Return<MetadataRequest>> GetMetadata(IEnumerable<string> listId)
        {
            var metadataRequests = new List<MetadataRequest>();
            
            _logger.LogInformation("Start get metadata");

            try
            {
                foreach (var id in listId)
                {
                    metadataRequests.Add(await _callCoinMarketCup.GetCryptoCurrencyMetadata(id));
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
                return Return<MetadataRequest>.ReturnFail("error_get_metadata");
            }

            return Return<MetadataRequest>.ReturnSuccessfully(CoinMarketCupHelpers.MetadataListToMetadata(metadataRequests));
        }

        private async Task<Return<ListingLatestRequest>> GetListingLatest()
        {
            _logger.LogInformation("Start get listing latest");

            try
            {
                return Return<ListingLatestRequest>
                    .ReturnSuccessfully(await _callCoinMarketCup.GetCryptoCurrencyListing());
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return Return<ListingLatestRequest>.ReturnFail("error_get_listing_latest");
            }

        }

        private async Task<IEnumerable<string>> GetIdCoin(ListingLatestRequest listingLatestRequest)
        {
            int counter = await _settingCryptocurrencyRepository.GetCountMetadata();
            int countMetadata = await _settingCryptocurrencyRepository.GetCountMetadata();

            return  listingLatestRequest.Data
                .Select(x => x.Id.ToString())
                .GroupBy(w => counter++ / countMetadata)
                .Select(w => w.ToArray())
                .Select(w => new StringBuilder().AppendJoin(',', w).ToString());
        }

    }
}
