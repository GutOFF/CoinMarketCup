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
using CoinMarketCup.Models.Dto;

namespace CoinMarketCup.Service
{
    public class CoinMarketCupService
    {
        private readonly CallCoinMarketCup _callCoinMarketCup;
        private readonly IMapper _mapper;

        public CoinMarketCupService(CallCoinMarketCup coinMarketCupHelpers, IMapper mapper)
        {
            _callCoinMarketCup = coinMarketCupHelpers;
            _mapper = mapper;
        }

        public async Task<Return<string>> GetInformationQuotes()
        {
            var listingLatestRequest = await GetListingLatest();

            if (!listingLatestRequest.IsTrue)
            {
                return Return<string>.ReturnFail(listingLatestRequest.Error);
            }

            var id = GetIdCoin(listingLatestRequest.Information);

            var metadataRequest = await GetMetadata(id);

            if (!metadataRequest.IsTrue)
            {
                return Return<string>.ReturnFail(listingLatestRequest.Error);
            }

            var test = new CryptoDto()
            {
                ListingLatestRequest = listingLatestRequest.Information,
                MetadataRequest = metadataRequest.Information
            };

            var rez = _mapper
                .Map<List<Cryptocurrency>>(test);


            return Return<string>.ReturnSuccessfully("ok");
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

    }
}
