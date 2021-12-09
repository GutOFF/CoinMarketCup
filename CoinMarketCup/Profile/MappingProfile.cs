using System.Linq;
using CoinMarketCup.Models.Dto;
using CoinMarketCup.Models.Request.CoinMarketCupRequest;
using Entity.Model;

namespace CoinMarketCup.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<CryptoCurrencyListingRequest, Cryptocurrency>()
                .ForMember(desk => desk.LastUpdated, opt => opt.MapFrom(src => src.Quote["USD"].LastUpdated))
                .ForMember(desk => desk.Price, opt => opt.MapFrom(src => src.Quote["USD"].Price))
                .ForMember(desk => desk.PercentChange1H, opt => opt.MapFrom(src => src.Quote["USD"].PercentChange1H))
                .ForMember(desk => desk.PercentChange24H, opt => opt.MapFrom(src => src.Quote["USD"].PercentChange24H));

            CreateMap<CryptoCurrencyMetadataRequest, Cryptocurrency>()
                .ForMember(desk => desk.Logo, opt => opt.MapFrom(src => src.Logo));


        }
    }
}
