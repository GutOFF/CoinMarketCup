using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoinMarketCup.Controllers
{

    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(AppRoleCreateModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(model.RoleName));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Roles");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("Error", error.Description);
                    }
                }
            }

            return View(model);
        }

        [HttpPost]
        // В этом методе открываем меню редактирвоания, для опередленной роли по его ID
        public async Task<IActionResult> Edit(string id) // у каждой role есть Id, сюда прилетает ID роли
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id); // ищем Id роли
            if (role == null)
            {
                return View("Error");
            }

            var members = new List<AppUserModel>();
            var nonMembers = new List<AppUserModel>();

            foreach (var user in _userManager.Users)
            {
                var isInRole = await _userManager.IsInRoleAsync(user, role.Name);
                if (isInRole) members.Add(user);
                else nonMembers.Add(user);
            }

            var model = new AppRoleEditModel()
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };
            return View(model);
        }

        [HttpPost]
        //Метод для добавления в группы, модифицируем добавляем в группы людей
        public async Task<IActionResult> Modify(AppRoleModifyModel model)
        {

            if (ModelState.IsValid)
            {

                foreach (var userId in model.IdsToAdd)//Вытаскиваем ID кого добавить
                {
                    AppUserModel user = await _userManager.FindByIdAsync(userId); // ищем User по ID
                    if (user != null)// Если не null то проходим
                    {
                        IdentityResult result = await _userManager.AddToRoleAsync(user, model.RoleName); // Добавляем в роль
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("Error", error.Description);
                            }
                        }
                    }
                }
                // Тут удаляем
                foreach (var userId in model.IdsToDelete)
                {
                    AppUserModel user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        IdentityResult result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("Error", error.Description);
                            }
                        }
                    }
                }

                return RedirectToAction("Index", "Roles");
            }

            return await Edit(model.RoleId);
        }
    }
}
