using Company.Data.Models;
using Company.web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Company.web.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RolesController> _logger;
        private readonly UserManager<ApplicationUser> _user;

        public RolesController(RoleManager<IdentityRole> roleManager   , 
            ILogger<RolesController> logger ,UserManager<ApplicationUser> user ) 
        {
           _roleManager = roleManager;
           _logger = logger;
           _user = user;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync(); 
            return View(roles);
        }
        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(role);
        }
        public async Task<IActionResult> Details(string id, string ViewName = "Details")
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var role = await _roleManager.FindByIdAsync(id);


            if (User == null)
            {
                return RedirectToAction("Index");
            }

            return View(ViewName, User);
        }
        public async Task<IActionResult> Update(string id)
        {
            return await Details(id, "Update");
        }
        [HttpPost]
        public async Task<IActionResult> Update(string id, RoleUpdateViewModel roleUpdateViewModel)
        {
            if (id != roleUpdateViewModel.RoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var role = await _roleManager.FindByIdAsync(id);

                    if (User is not null)
                    {
                        return NotFound();

                    }
                    role.Name = role.Name;
                    role.NormalizedName = roleUpdateViewModel.RoleName.ToUpper();

                    var result =await _roleManager.UpdateAsync(role);
            
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("role Updated Successfuly");

                        return RedirectToAction("Index");
                    }
                    foreach (var item in result.Errors)
                    {
                        _logger.LogError(item.Description);
                    }
                }

                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
                }

            }
            return View(roleUpdateViewModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _roleManager .FindByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                _logger.LogInformation("User Deleted Successfully");
                return RedirectToAction("Index");
            }

            foreach (var item in result.Errors)
            {
                _logger.LogError(item.Description);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddOrRemoveUsers(string roleid)
        {
            var role =await _roleManager.FindByIdAsync(roleid);
            if (role is null)
            {return NotFound();

            }
            var users =await _user.Users.ToListAsync();
            var usersInRole = new List<UserInRoleViewModel>();

            foreach (var user in users)
            {
                var userInRole = new UserInRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                
                };
               if (await _user.IsInRoleAsync(user, role.Name))
                {
                    userInRole.IsSelected = true;
                }
               else
                    userInRole.IsSelected= false;

            }
            return View(usersInRole);
        }
        public async Task<IActionResult> AddOrRemoveUsers(string roleId, List<UserInRoleViewModel> users)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role is null)
            {
                return NotFound();
            }
            if (ModelState.IsValid) {
                foreach (var user in users)
                {
                    var appUser = await _user.FindByIdAsync(user.UserId);
                    if (appUser is not null)
                    {
                        if (user.IsSelected && !await _user.IsInRoleAsync(appUser, role.Name))
                        {
                            await _user.AddToRoleAsync(appUser, role.Name);
                        }
                        else if (!user.IsSelected && !await _user.IsInRoleAsync(appUser, role.Name)
                            await _user.RemoveFromRoleAsync(appUser, role.Name);
                    }
                }
                return RedirectToAction("Update", new { id = roleId });
            }
            return View(users);
        }
    }
}
