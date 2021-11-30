using CoinMarketCup.Models.Request;
using CoinMarketCup.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoinMarketCup.Controllers
{
    public class AccountController : Controller
    {
        private readonly LoginService _loginService;
        public AccountController(LoginService loginService)
        {
            _loginService = loginService;
        }
       
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Invalid user email or password");
            }

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
