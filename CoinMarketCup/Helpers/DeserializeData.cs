using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoinMarketCup.Helpers
{
    public class DeserializeData<T> where T : class
    {
        public T Deserialize(string dataJson)
        {
            var data = JsonConvert.DeserializeObject<T>(dataJson, new JsonSerializerSettings()
                { NullValueHandling = NullValueHandling.Ignore });
            return data;
        } 
     
    }
}
