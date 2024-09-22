using Company.Data.Models;
using Company.Servies.Interfaces.services.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.web.Controllers
{
   
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly ILogger _logger;

        public UserController(UserManager<ApplicationUser> userManger ,ILogger<UserController> logger)
        {
            _userManger = userManger;
          _logger = logger;
        }
        public async  Task <IActionResult> Index(string searchInp)
        {
            List<ApplicationUser> users;
            if (string.IsNullOrEmpty(searchInp))
            {
                users = await _userManger.Users.ToListAsync();
            }
            else
            {
                users = await _userManger.Users.Where(users => users.NormalizedEmail.Trim().Contains(searchInp.Trim().ToUpper())).ToListAsync();

            }
            return View(users);
        }
        public async Task <IActionResult> Details(string id, string ViewName = "Details")
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var User = await _userManger.FindByIdAsync(id);


            if (User == null)
            {
                return RedirectToAction("Index");
            }

            return View(ViewName, User);
        }
        public  async Task<IActionResult> Update(string id)
        {
            return await Details(id, "Update");
        }
        [HttpPost]
        public async Task<IActionResult> Update(string id, ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var User = await _userManger.FindByIdAsync(id);

                    if (User is not null)
                    {
                        return NotFound();

                    }
                    User.UserName = applicationUser.UserName;
                   // User.LastName = applicationUser.LastName;
                    User.Email = applicationUser.Email;
                    User.NormalizedUserName = applicationUser.UserName.ToUpper();
                    var result =await _userManger.UpdateAsync(User);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User Updated Successfuly");

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
            return View(applicationUser);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManger.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManger.DeleteAsync(user);

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


    }
}
