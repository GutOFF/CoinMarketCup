using CoinMarketCup.Models.Request;
using CoinMarketCup.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoinMarketCup.Controllers
{

    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleService _roleService;

        public RolesController(RoleService roleService)
        {
            _roleService = roleService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create(RoleCreateRequest model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "error_create_role");
                return BadRequest();
            }

            var result = await _roleService.CreateRole(model.RoleName, model.IsPublish);

            return View(result);
        }

    }
}
