using System;
using AutoMapper;
using CoinMarketCup.API;
using CoinMarketCup.Models;
using CoinMarketCup.Models.Request.CoinMarketCupRequest;
using CoinMarketCup.Monad;
using CoinMarketCup.Repository;
using Entity.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinMarketCup.Service
{
    public class CoinMarketCupService
    {
        private readonly CallCoinMarketCup _callCoinMarketCup;
        private readonly CoinMarketRepository _coinMarketRepository;
        private readonly SettingCryptocurrencyRepository _settingCryptocurrencyRepository;


        public CoinMarketCupService(CallCoinMarketCup coinMarketCupHelpers, CoinMarketRepository coinMarketRepository, SettingCryptocurrencyRepository settingCryptocurrencyRepository)
        {
            _callCoinMarketCup = coinMarketCupHelpers;
            _coinMarketRepository = coinMarketRepository;
            _settingCryptocurrencyRepository = settingCryptocurrencyRepository;
        }

        public async Task<Return<List<Cryptocurrency>>> GetOrCreateCryptocurrencies(PaginatorInfoModel paginatorInfo, SortState sortState)
        {
            if (await _coinMarketRepository.IsExpiryDateExpired())
            {
                await _coinMarketRepository.DeleteAllDate();

                bool isRecord = await DateRecord();

                if (!isRecord)
                {
                    return Return<List<Cryptocurrency>>.ReturnFail("record_fail");
                }
            }

            var result = await _coinMarketRepository.GetCryptocurrencies(paginatorInfo, sortState);

            return Return<List<Cryptocurrency>>.ReturnSuccessfully(result);

        }


        public async Task<bool> DateRecord()
        {
            var cryptocurrencies = await GetCryptocurrencies();

            if (!cryptocurrencies.IsSuccessfully)
            {
                return false;
            }
            await _coinMarketRepository.AddRange(cryptocurrencies.Information);

            return true;
        }

        public async Task<Return<List<Cryptocurrency>>> GetCryptocurrencies()
        {
            var listingLatestRequest = await GetListingLatest();

            if (!listingLatestRequest.IsSuccessfully)
            {
                return Return<List<Cryptocurrency>>.ReturnFail(listingLatestRequest.Error);
            }

            var listId = await GetIdCoin(listingLatestRequest.Information);

            var metadataRequest = await GetMetadata(listId);

            return !metadataRequest.IsSuccessfully ? Return<List<Cryptocurrency>>.ReturnFail(listingLatestRequest.Error)
                : Return<List<Cryptocurrency>>.ReturnSuccessfully(await ObjectShapingCryptocurrencies(listingLatestRequest.Information, metadataRequest.Information));
        }

        private async Task<Return<MetadataRequest>> GetMetadata(IEnumerable<string> listId)
        {
            var metadataRequests = new List<MetadataRequest>();

            try
            {
                foreach (var id in listId)
                {
                    metadataRequests.Add(await _callCoinMarketCup.GetCryptoCurrencyMetadata(id));
                }
            }
            catch(Exception e)
            {
                return Return<MetadataRequest>.ReturnFail("error_get_metadata");
            }

            return Return<MetadataRequest>.ReturnSuccessfully(MetadataListToMetadata(metadataRequests));
        }

        private async Task<Return<ListingLatestRequest>> GetListingLatest()
        {
            try
            {
                return Return<ListingLatestRequest>
                    .ReturnSuccessfully(await _callCoinMarketCup.GetCryptoCurrencyListing());
            }
            catch
            {
                return Return<ListingLatestRequest>.ReturnFail("error_get_listing_latest");
            }
        }

        private async Task<IEnumerable<string>> GetIdCoin(ListingLatestRequest listingLatestRequest)
        {
            int counter = await _settingCryptocurrencyRepository.GetCountMetadata();
            int i = await _settingCryptocurrencyRepository.GetCountMetadata();

            StringBuilder stringBuilder = new StringBuilder();
            var result = new List<string>();

            var listId = listingLatestRequest.Data
                .Select(x => x.Id.ToString())
                .GroupBy(w => counter++ / i)
                .Select(w => w.ToArray())
                .ToList();

            foreach (var id in listId)
            {
                stringBuilder.Clear();
                stringBuilder.AppendJoin(',', id);
                result.Add(stringBuilder.ToString());
            }

            return result;
        }

        private async Task<List<Cryptocurrency>> ObjectShapingCryptocurrencies(ListingLatestRequest listingLatestRequest, MetadataRequest metadataRequest)
        {
            string fiatValue = await _settingCryptocurrencyRepository.GetFiatCurrency();

            return listingLatestRequest.Data.Select(item => new Cryptocurrency()
            {
                CoinMarketCupId = item.Id,
                Name = item.Name,
                Symbol = item.Symbol,
                Logo = metadataRequest.Data[item.Id.ToString()].Logo,
                LastUpdated = item.Quote[fiatValue].LastUpdated,
                MarketCap = item.Quote[fiatValue].MarketCap,
                PercentChange1H = item.Quote[fiatValue].PercentChange1H,
                PercentChange24H = item.Quote[fiatValue].PercentChange24H,
                Price = item.Quote[fiatValue].Price
            })
                .ToList();
        }

        private static MetadataRequest MetadataListToMetadata(IReadOnlyCollection<MetadataRequest> metadataRequests)
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

    }
}
