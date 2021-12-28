using CoinMarketCup.Models.Request;
using CoinMarketCup.Monad;
using CoinMarketCup.Repository;
using Entity.Model;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CoinMarketCup.Service
{
    public class LoginService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signManager;
        private readonly RoleRepository _roleRepository;
        public LoginService(SignInManager<User> signManager, UserManager<User> userManager, RoleRepository roleRepository)
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
            if (!await _roleRepository.IsPublishRole(model.RoleName.ToUpper()))
            {
                return Return<bool>.ReturnFail("role_not_fond");
            }

            var role = await _roleRepository
                .GetRoleByNormalizedName(model.RoleName.ToUpper());

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

            await _userManager.AddToRoleAsync(user, role.Name);

            return Return<bool>.ReturnSuccessfully(true);
        }

    }
}
