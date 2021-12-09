using System;

namespace CoinMarketCup.Models
{
    public class PaginatorInfoModel
    {
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int PageSize { get; set; } 
        public int PagesCount => (int)
            Math.Ceiling(TotalItems / (float)PageSize);
    }
}
