using System;
using CoinMarketCup.Models.Request;
using CoinMarketCup.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CoinMarketCup.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly LoginService _loginService;
        private readonly CoinMarketCupService _coinMarketCupService;

        public AccountController(LoginService loginService, CoinMarketCupService coinMarketCupService)
        {
            _loginService = loginService;
            _coinMarketCupService = coinMarketCupService;
        }
       
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Invalid user email or password");
                return View(loginRequest);
            }

            await _coinMarketCupService.GetOrCreateCryptocurrencies();
            var result = await _loginService.Login(loginRequest);
            
            if (result.IsTrue)
            {
                RedirectToAction("Index", "Home");
            }
           
            return View(loginRequest);
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration(RegistrationRequest registrationRequest)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Invalid user email or password");
                return View(registrationRequest);
            }

            var result = await _loginService.Registration(registrationRequest);
           
            if (result.IsTrue)
            {
                return RedirectToAction("Login", "Account");
            }
           
            return View(registrationRequest);
        }

        [Authorize]
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            var result = await _loginService.Logout();
            return View(result);
        }
    }
}
