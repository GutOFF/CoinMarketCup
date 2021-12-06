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

            CreateMap<CryptoDto, Cryptocurrency>()
                .ForMember(desk => desk.Name,
                    opt => opt.MapFrom(src => src.ListingLatestRequest.Data.Select(w => w.Name)))
               
                .ForMember(desk => desk.Price,
                    opt => opt.MapFrom(src => src.ListingLatestRequest.Data.Select(w => w.Quote["USD"].Price)))
               
                .ForMember(desk => desk.PercentChange1H,
                    opt => opt.MapFrom(src =>
                        src.ListingLatestRequest.Data.Select(w => w.Quote["USD"].PercentChange1H)))
              
                .ForMember(desk => desk.PercentChange24H,
                    opt => opt.MapFrom(
                        src => src.ListingLatestRequest.Data.Select(w => w.Quote["USD"].PercentChange24H)))
              
                .ForMember(desk => desk.Price,
                    opt => opt.MapFrom(src => src.ListingLatestRequest.Data.Select(w => w.Quote["USD"].Price)))
                
                .ForMember(desk => desk.MarketCap,
                    opt => opt.MapFrom(src => src.ListingLatestRequest.Data.Select(w => w.Quote["USD"].MarketCap)))
               
                .ForMember(desk => desk.Id,
                    opt => opt.MapFrom(src => src.ListingLatestRequest.Data.Select(w => w.Id)))
           
                .ForMember(desk => desk.Logo, opt => opt.MapFrom(src => src.MetadataRequest.Data.Values.Select(w => w.Logo)));
        }
    }
}
