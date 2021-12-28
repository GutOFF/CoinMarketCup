using CoinMarketCup.Models.Request.CoinMarketCupRequest;
using Entity.Model;

namespace CoinMarketCup.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<CryptoCurrencyMetadataRequest, Cryptocurrency>()
                .ForMember(desk => desk.Logo, opt => opt.MapFrom(src => src.Logo));
        }
    }
}
