using System.Threading.Tasks;
using AutoMapper;
using CoinMarketCup.Models;
using CoinMarketCup.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoinMarketCup.Controllers
{
    public class CoinMarketCupController : Controller
    {
        private readonly CoinMarketCupService _coinMarketCupService;
        private readonly IMapper _mapper;
 
        public CoinMarketCupController(CoinMarketCupService coinMarketCupService, int pageSize, IMapper mapper)
        {
            _coinMarketCupService = coinMarketCupService;
            _mapper = mapper;
        }

        [HttpGet("get-information-quotes")]
        public async Task<IActionResult> GetInformationQuotes(string sortOrder = "market_cap", int page = 1)
        {
            var infoPaginator = new PaginatorInfoModel()
            {
                PageSize = 20,
                CurrentPage = page,
                TotalItems = 5000
            };

            var result = await _coinMarketCupService.GetOrCreateCryptocurrencies(infoPaginator);
          
            if (!result.IsTrue)
            {
                return BadRequest();
            }

            //_mapper.Map<>()
            return View(result);
        }

    }
}
