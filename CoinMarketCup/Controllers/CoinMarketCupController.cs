using System.Threading.Tasks;
using AutoMapper;
using CoinMarketCup.Models;
using CoinMarketCup.Models.Dto;
using CoinMarketCup.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoinMarketCup.Controllers
{
    public class CoinMarketCupController : Controller
    {
        private readonly CoinMarketCupService _coinMarketCupService;

        public CoinMarketCupController(CoinMarketCupService coinMarketCupService)
        {
            _coinMarketCupService = coinMarketCupService;
        }

     [AllowAnonymous]
        public async Task<IActionResult> GetInformationQuotes(SortState sortOrder = SortState.MarketCap, int page = 1)
        {
            
            
            var infoPaginator = new PaginatorInfoModel()
            {
                PageSize = 20,
                CurrentPage = page,
                TotalItems = 5000
            };

            var result = await _coinMarketCupService.GetOrCreateCryptocurrencies(infoPaginator, sortOrder);
          
            if (!result.IsTrue)
            {
                return BadRequest();
            }

            var model = new QuotePageDto()
            {
                Cryptocurrencies = result.Information,
                Info = infoPaginator
            };

            ViewBag.SortOrder = sortOrder;

            return View(model);
        }

    }
}
