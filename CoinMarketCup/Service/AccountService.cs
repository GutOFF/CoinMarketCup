using CoinMarketCup.Models.Request;
using CoinMarketCup.Monad;
using CoinMarketCup.Repository;
using Entity.Model;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CoinMarketCup.Service
{
    public class AccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signManager;
        private readonly RoleRepository _roleRepository;
        public AccountService(SignInManager<User> signManager, UserManager<User> userManager, RoleRepository roleRepository)
        {
            _signManager = signManager;
            _userManager = userManager;
            _roleRepository = roleRepository;
        }

        public async Task<Return<bool>> Login(LoginRequest model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
            {
                return Return<bool>.ReturnFail("user_is_null");
            }
            var result = await _signManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

            return !result.Succeeded ? Return<bool>.ReturnFail("failed_to_login") : Return<bool>.ReturnSuccessfully(true);
        }

        public async Task<Return<bool>> Logout()
        {
            await _signManager.SignOutAsync();
            return Return<bool>.ReturnSuccessfully(true);
        }
        public async Task<Return<bool>> Registration(RegistrationRequest model)
        {
            if (!await _roleRepository.IsPublicRole(model.RoleName.ToUpper()))
            {
                return Return<bool>.ReturnFail("role_not_fond");
            }

            var role = await _roleRepository
                .GetRoleByNormalizedName(model.RoleName.ToUpper());

            var user = new User()
            {
                UserName = model.Name,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return Return<bool>.ReturnFail("failed_to_create");
            }

            await _userManager.AddToRoleAsync(user, role.Name);

            return Return<bool>.ReturnSuccessfully(true);
        }

    }
}
