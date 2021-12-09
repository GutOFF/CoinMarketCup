using Entity.Model;
using System.Collections.Generic;

namespace CoinMarketCup.Models.Dto
{
    public class QuotePageDto
    {
        public List<Cryptocurrency> Cryptocurrencies { get; set; }
        public PaginatorInfoModel Info { get; set; }
    }
}
