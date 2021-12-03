using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinMarketCup.Models.Dto
{
    public class ParametersListingLatesDto
    {
        public int Start { get; set; }
        public int Limit { get; set; }
        public string PriceMin { get; set; }
        public string PriceMax { get; set; }
        public string MaretCapMax { get; set; }
        public string MaretCapMin { get; set; }
        public string VolumeDayMin { get; set; }
        public string VolumeDayMax { get; set; }
        public string CirculatingSupplyMin { get; set; }
        public string CirculatingSupplyMax { get; set; }
        public string PercentChangeDayMin { get; set; }
        public string PercentChangeDayMax { get; set; }
        public string Convert { get; set; }
        public string ConvertId { get; set; }
        public string Sort { get; set; }
        public string SortDir { get; set; }
        public string CryptocurrencyType { get; set; }
        public string Tag { get; set; }
        public string Aux { get; set; }
    }
}
