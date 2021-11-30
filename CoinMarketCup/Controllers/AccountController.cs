using System.Threading.Tasks;
using CoinMarketCup.Models.Request;
using CoinMarketCup.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoinMarketCup.Controllers
{
    public class AccountController : Controller
    {
        private readonly LoginService _loginService;
        public AccountController(LoginService loginService)
        {
            _loginService = loginService;
        }
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var result = await _loginService.Login();
            return View(result.Information);
        }

    }
}
