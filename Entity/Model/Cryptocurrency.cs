using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Model
{
    public class Cryptocurrency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public decimal PercentChange1H { get; set; }
        public decimal PercentChange24H { get; set; }
        public decimal MarketCap { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
