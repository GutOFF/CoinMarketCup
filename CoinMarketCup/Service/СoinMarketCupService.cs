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
        private readonly IMapper _mapper;
        private readonly CoinMarketRepository _coinMarketRepository;


        public CoinMarketCupService(CallCoinMarketCup coinMarketCupHelpers, IMapper mapper, CoinMarketRepository coinMarketRepository)
        {
            _callCoinMarketCup = coinMarketCupHelpers;
            _mapper = mapper;
            _coinMarketRepository = coinMarketRepository;
        }

        public async Task<Return<List<Cryptocurrency>>> GetOrCreateCryptocurrencies(PaginatorInfoModel paginatorInfo, SortState sortState)
        {
            if (await _coinMarketRepository.IsExpiryDateExpired())
            {
                await _coinMarketRepository.DeleteAllDate();

                var cryptorency = await GetCryptocurrencies();

                if (!cryptorency.IsSuccessfully)
                {
                    return Return<List<Cryptocurrency>>.ReturnFail("error");
                }

                await DateRecord(cryptorency.Information);
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
                return Return<List<Cryptocurrency>>.ReturnFail(listingLatestRequest.Error);
            }

            var listId = GetIdCoin(listingLatestRequest.Information);

            var metadataRequest = await GetMetadata(listId);

            if (!metadataRequest.IsSuccessfully)
            {
                return Return<List<Cryptocurrency>>.ReturnFail(listingLatestRequest.Error);
            }

            return Return<List<Cryptocurrency>>.ReturnSuccessfully(ObjectShapingCryptocurrencies(listingLatestRequest.Information, metadataRequest.Information));
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
            catch
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

        private static IEnumerable<string> GetIdCoin(ListingLatestRequest listingLatestRequest)
        {
            int counter = 20;
            StringBuilder stringBuilder = new StringBuilder();
            var result = new List<string>();

            var listId = listingLatestRequest.Data
                .Select(x => x.Id.ToString())
                .GroupBy(w => counter++ / 20)
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

        private static List<Cryptocurrency> ObjectShapingCryptocurrencies(ListingLatestRequest listingLatestRequest, MetadataRequest metadataRequest)
        {
            return listingLatestRequest.Data.Select(item => new Cryptocurrency()
            {
                CoinMarketCupId = item.Id,
                Name = item.Name,
                Symbol = item.Symbol,
                Logo = metadataRequest.Data[item.Id.ToString()].Logo,
                LastUpdated = item.Quote["USD"].LastUpdated,
                MarketCap = item.Quote["USD"].MarketCap,
                PercentChange1H = item.Quote["USD"].PercentChange1H,
                PercentChange24H = item.Quote["USD"].PercentChange24H,
                Price = item.Quote["USD"].Price
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
