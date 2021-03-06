using CoinMarketCup.Models.Request;
using CoinMarketCup.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoinMarketCup.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
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

            var result = await _accountService.Login(loginRequest);
            
            if (result.IsSuccessfully)
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegistrationRequest registrationRequest)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Invalid user email or password");
                return View(registrationRequest);
            }

            var result = await _accountService.Registration(registrationRequest);
           
            if (result.IsSuccessfully)
            {
                return RedirectToAction("Login", "Account");
            }
           
            return View(registrationRequest);
        }

        [Authorize]
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            var result = await _accountService.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
