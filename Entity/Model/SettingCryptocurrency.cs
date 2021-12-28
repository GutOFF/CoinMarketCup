using System;

namespace Entity.Model
{
    public class SettingCryptocurrency
    {
        public int Id { get; set; }
        public int Limit { get; set; }
        public string ApiKey { get; set; }
        public int MaxCountMetadata { get; set; }
        public int ExpiryDateExpired { get; set; }
        public string FiatCurrency { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
