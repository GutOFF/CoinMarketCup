using System.Threading.Tasks;
using CoinMarketCup.Monad;
using Entity.Model;
using Microsoft.AspNetCore.Identity;

namespace CoinMarketCup.Service
{
    public class LoginService
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signManager;

        public LoginService(SignInManager<User> signManager, UserManager<User> userManager)
        {
            _signManager = signManager;
            _userManager = userManager;
        }

        public Task<Return<bool>> Login(string email, string password)
        {

        }
    }
}
