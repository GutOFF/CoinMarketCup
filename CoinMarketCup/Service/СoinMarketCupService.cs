using System;
using AutoMapper;
using CoinMarketCup.API;
using CoinMarketCup.Models.Request.CoinMarketCupRequest;
using CoinMarketCup.Monad;
using Entity.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinMarketCup.Repository;

namespace CoinMarketCup.Service
{
    public class CoinMarketCupService
    {
        private readonly CallCoinMarketCup _callCoinMarketCup;
        private readonly IMapper _mapper;
        private readonly CoinMarketRepository _coinMarketRepository;

        public CoinMarketCupService(CallCoinMarketCup coinMarketCupHelpers, IMapper mapper, CoinMarketRepository coinMarketRepository)
        {
            _callCoinMarketCup = coinMarketCupHelpers;
            _mapper = mapper;
            _coinMarketRepository = coinMarketRepository;
        }

        public async Task<Return<Cryptocurrency>> GetOrCreateCryptocurrencies()
        {
            if (await _coinMarketRepository.IsExpiryDateExpired())
            {
                await DateRecord();
            }
            await DateRecord();
            return Return<Cryptocurrency>.ReturnSuccessfully(await _coinMarketRepository.GetById("1"));

        }

        public async Task<bool> DateRecord()
        {
            var cryptocurrency = await GetCryptocurrencies();

            if (!cryptocurrency.IsTrue)
            {
                return false;
            }

            try
            {

                await _coinMarketRepository.AddRange(cryptocurrency.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           

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
            catch
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
                    Id = item.Id,
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
