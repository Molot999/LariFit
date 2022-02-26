using LariFit.Models;
using LariFit.ViewModels;
using LariFit.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LariFit.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditPersonalData(EditPersonalDataViewModel model)
        {
            User user = await userManager.FindByIdAsync(model.Id);

            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    user.Calories = model.Calories;
                    user.TargetWeight = model.TargetWeight;
                    user.Height = model.Height;
                    user.BirthDate = model.BirthDate;

                    IdentityResult editPersonalDataResult = await userManager.UpdateAsync(user);

                    if (editPersonalDataResult.Succeeded)
                    {
                        return View(new EditPersonalDataViewModel(user.Id, user.Calories, user.TargetWeight, user.Height, user.BirthDate));
                    }
                    else
                    {
                        foreach (var error in editPersonalDataResult.Errors)
                            ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                
                return View(new EditPersonalDataViewModel(user.Id, user.Calories, user.TargetWeight, user.Height, user.BirthDate));
            }

            return View(new EditPersonalDataViewModel(user.Id, user.Calories, user.TargetWeight, user.Height, user.BirthDate));
        }

        [HttpGet]
        [Authorize] 
        public async Task<IActionResult> EditPersonalData()
        {
            User user = await userManager.FindByIdAsync(userManager.GetUserId(User));

            if (user != null)
                return View(new EditPersonalDataViewModel(user.Id, user.Calories, user.TargetWeight, user.Height, user.BirthDate));
            else
                return NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model)
        {
            User user = await userManager.FindByIdAsync(model.Id);

            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    user.UserName = model.UserName;

                    IdentityResult editDataResult = await userManager.UpdateAsync(user);

                    if (editDataResult.Succeeded )
                    {
                        return View(new EditProfileViewModel() { Id = user.Id, UserName = user.UserName });
                    } 
                    else
                    {
                        foreach (var error in editDataResult.Errors)
                            ModelState.AddModelError(string.Empty, error.Description);
                    }


                }
                else
                {
                    return NotFound();
                }

                return View(new EditProfileViewModel() { Id = user.Id, UserName = user.UserName });
            }

            return NotFound();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditProfile()
        {
            User user = await userManager.FindByIdAsync(userManager.GetUserId(User));

            if (user != null)
                return View(new EditProfileViewModel() { Id = user.Id, UserName = user.UserName });
            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User() { UserName = model.UserName };
                
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model);

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("EditProfile", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

