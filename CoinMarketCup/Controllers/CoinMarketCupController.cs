using CoinMarketCup.Models;
using CoinMarketCup.Models.Dto;
using CoinMarketCup.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoinMarketCup.Controllers
{
    public class CoinMarketCupController : Controller
    {
        private readonly CoinMarketCupService _coinMarketCupService;

        public CoinMarketCupController(CoinMarketCupService coinMarketCupService)
        {
            _coinMarketCupService = coinMarketCupService;
        }

        public async Task<IActionResult> GetInformationQuotes(SortState sortOrder = SortState.MarketCap, int page = 1)
        {
            var infoPaginator = new PaginatorInfoModel()
            {
                PageSize = 20,
                CurrentPage = page,
                TotalItems = 5000
            };

            var result = await _coinMarketCupService.GetOrCreateCryptocurrencies(infoPaginator, sortOrder);

            if (!result.IsSuccessfully)
            {
                return View("Error");
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
