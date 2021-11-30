using System.Threading.Tasks;
using CoinMarketCup.Models.Request;
using CoinMarketCup.Monad;
using Entity.Model;
using Microsoft.AspNetCore.Identity;

namespace CoinMarketCup.Service
{
    public class LoginService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signManager;

        public LoginService(SignInManager<User> signManager, UserManager<User> userManager)
        {
            _signManager = signManager;
            _userManager = userManager;
        }

        public async Task<Return<bool>> Login(LoginRequest model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
            {
                return Return<bool>.ReturnFail("user_is_null");
            }

            await _signManager.SignOutAsync();

            var result = await _signManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                return Return<bool>.ReturnFail("failed_to_login");
            }

            return Return<bool>.ReturnSuccessfully(true);
        }

        public async Task<Return<bool>> Logout()
        {
           await _signManager.SignOutAsync();
           return Return<bool>.ReturnSuccessfully(true);
        }
        public async Task<Return<bool>> Registration(RegistrationRequest model)
        {

            User user = new User()
            {
                UserName = model.Name,
                Email = model.Email
            };

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return Return<bool>.ReturnFail("failed_to_create");
            }

            return Return<bool>.ReturnSuccessfully(true);
        }

    }
}
