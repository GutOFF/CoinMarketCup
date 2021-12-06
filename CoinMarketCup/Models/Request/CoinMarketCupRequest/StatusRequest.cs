using System;
using Newtonsoft.Json;

namespace CoinMarketCup.Models.Request.CoinMarketCupRequest
{
    public class StatusRequest
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }
      
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
        
        [JsonProperty("elapsed")]
        public int Elapsed { get; set; }

        [JsonProperty("creditCount")]
        public int CreditCount { get; set; }

    }
}
    