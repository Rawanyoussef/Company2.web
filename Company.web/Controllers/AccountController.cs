using Company.Data.Models;
using Company.Servies.Helper;
using Company.web.Models;
using Company.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Company.web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager ,SignInManager<ApplicationUser> SignInManager)
        {
          _userManager = userManager;
            _signInManager = SignInManager;
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> SignUp(SignUpViewModel input)
        {

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Email = input.Email,
                    UserName = input.Email.Split('@')[0],
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    IsActive = true
                };
                var result =await _userManager.CreateAsync(user ,input.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("signIn");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Login(LoginViewModel input)
        {
           if (ModelState.IsValid)
            {
                var user =await _userManager.FindByEmailAsync(input.Email);
                if (user is not null)
                {
                    if(await _userManager.CheckPasswordAsync(user, input.Password))
                    {
                        var result =await _signInManager.PasswordSignInAsync(user,input.Password ,input.RemmberMe,true);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }

                    ModelState.AddModelError("","Incorrect Email")
                        ; return View(input);
                }
               
            }
            return View(input);
        }
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

       public IActionResult ForgetPassWord()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> ForgetPassWord(ForgetPassWordViewModel input)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(input.Email);
                if (user is not null)
                {
                    var token =await _userManager.GeneratePasswordResetTokenAsync(user);
                    var url = Url.Action("ResetPassword", "Account", new { email = input.Email, Token = token }, Request.Scheme);
                    var email = new Email
                    {
                        Body = url,
                        Subject = "Reset Pasword",
                        To = input.Email,
                    };
                    EmailSetting.SendEmail(email);
                    return RedirectToAction(nameof(CheckYourInbox));
                }
            }
            return View(input);
        }
        public IActionResult CheckYourInbox()
        {
            return View();  
        }
        public IActionResult ResetPassword(string Email ,string Token)
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> ResetPassword(ResetPasswordViewModel input)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(input.Email);
                if (user is not null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, input.Token ,input.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Login));
                    }
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(input);
        }


    }
}

