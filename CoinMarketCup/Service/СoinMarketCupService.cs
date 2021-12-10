using System;
using AutoMapper;
using CoinMarketCup.API;
using CoinMarketCup.Models.Request.CoinMarketCupRequest;
using CoinMarketCup.Monad;
using CoinMarketCup.Repository;
using Entity.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CoinMarketCup.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CoinMarketCup.Service
{
    public class CoinMarketCupService
    {
        private readonly CallCoinMarketCup _callCoinMarketCup;
        private readonly IMapper _mapper;
        private readonly CoinMarketRepository _coinMarketRepository;
        private IMemoryCache _cache;

        public CoinMarketCupService(CallCoinMarketCup coinMarketCupHelpers, IMapper mapper, CoinMarketRepository coinMarketRepository, IMemoryCache cache)
        {
            _callCoinMarketCup = coinMarketCupHelpers;
            _mapper = mapper;
            _coinMarketRepository = coinMarketRepository;
            _cache = cache;
        }

        public async Task<Return<List<Cryptocurrency>>> GetOrCreateCryptocurrencies(PaginatorInfoModel paginatorInfo, SortState sortState)
        {

            if (await _coinMarketRepository.IsExpiryDateExpired())
            {
                await _coinMarketRepository.DeleteAllDate();
                await DateRecord();
            }

            var result = await _coinMarketRepository.GetCryptocurrency(paginatorInfo, sortState);

            return Return<List<Cryptocurrency>>.ReturnSuccessfully(result);

        }

        public async Task<bool> DateRecord()
        {
            var cryptocurrency = await GetCryptocurrencies();

            if (!cryptocurrency.IsTrue)
            {
                return false;
            }

            await _coinMarketRepository.AddRange(cryptocurrency.Information);
           
            //_cache.Set(nameof(Cryptocurrency),cryptocurrency.Information, new MemoryCacheEntryOptions
            //{
            //    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            //});

            return true;
        }
        public async Task<Return<List<Cryptocurrency>>> GetCryptocurrencies()
        {
            var listingLatestRequest = await GetListingLatest();

            if (!listingLatestRequest.IsTrue)
            {
                return Return<List<Cryptocurrency>>.ReturnFail(listingLatestRequest.Error);
            }

            var id = GetIdCoin(listingLatestRequest.Information);

            var metadataRequest = await GetMetadata(id);

            if (!metadataRequest.IsTrue)
            {
                return Return<List<Cryptocurrency>>.ReturnFail(listingLatestRequest.Error);
            }

            var cryptocurrency = ObjectShapingCryptocurrencies(listingLatestRequest.Information, metadataRequest.Information);

            return Return<List<Cryptocurrency>>.ReturnSuccessfully(cryptocurrency);
        }

        private async Task<Return<MetadataRequest>> GetMetadata(string id)
        {
            try
            {
                return Return<MetadataRequest>
                    .ReturnSuccessfully(await _callCoinMarketCup.GetCryptoCurrencyMetadata(id));
            }
            catch(Exception e)
            {
                return Return<MetadataRequest>.ReturnFail("error");
            }
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
                return Return<ListingLatestRequest>.ReturnFail("error");
            }
        }

        private string GetIdCoin(ListingLatestRequest listingLatestRequest)
        {
            var listId = listingLatestRequest.Data
                .Select(x => x.Id.ToString())
                .ToList();

            StringBuilder stringBuilder = new StringBuilder();

            return stringBuilder
                .AppendJoin(',', listId)
                .ToString();
        }

        private List<Cryptocurrency> ObjectShapingCryptocurrencies(ListingLatestRequest listingLatestRequest, MetadataRequest metadataRequest)
        {
            var listCryptocurrency = new List<Cryptocurrency>();

            foreach (var item in listingLatestRequest.Data)
            {
                listCryptocurrency.Add(new Cryptocurrency()
                {
                    Name = item.Name,
                    Symbol = item.Symbol,
                    Logo = metadataRequest.Data[item.Id.ToString()].Logo,
                    LastUpdated = item.Quote["USD"].LastUpdated,
                    MarketCap = item.Quote["USD"].MarketCap,
                    PercentChange1H = item.Quote["USD"].PercentChange1H,
                    PercentChange24H = item.Quote["USD"].PercentChange24H,
                    Price = item.Quote["USD"].Price
                });
            }

            return listCryptocurrency;
        }

    }
}
