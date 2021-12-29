using System.Collections.Generic;
using System.Threading.Tasks;
using CoinMarketCup.Models;
using CoinMarketCup.Monad;
using Entity.Model;

namespace CoinMarketCup.Interface
{
    public interface ICoinMarketCupService
    {
        Task<Return<List<Cryptocurrency>>> GetOrCreateCryptocurrencies(PaginatorInfoModel paginatorInfo, SortState sortState);
        Task UpdateOrCreateDate(List<Cryptocurrency> cryptocurrencies);
        Task<Return<List<Cryptocurrency>>> GetCryptocurrenciesOnApi();
    }

}
