using CoinMarketCup.Service;
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

        [HttpGet("get-information-quotes")]
        public IActionResult GetInformationQuotes()
        {
            var result = _coinMarketCupService.GetInformationQuotes();
            return View(result);
        }

    }
}
