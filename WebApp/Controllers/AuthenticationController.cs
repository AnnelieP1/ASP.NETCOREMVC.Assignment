using Azure.Identity;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers;

public class AuthenticationController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

    #region SignUp

    [HttpGet]
    [Route("/register")]
    public IActionResult SignUp()
    {
        return View();
    }


    [HttpPost]
    [Route("/register")]
    public async Task<IActionResult> SignUp(SignUpViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (!await _userManager.Users.AnyAsync(x => x.Email == model.Email))
            {
                var userEntity = new UserEntity
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email

                };

                var result = await _userManager.CreateAsync(userEntity, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "AuthenticationController");
                }
                else
                {
                    ViewData["StatusMessage"] = "Something went wrong! Please try again.";
                }
            }
            else
            {
                ViewData["StatusMessage"] = "User with the same email address already exists.";
            }

        }

        return View(model);
    }

    #endregion

    #region SignIn

    [HttpGet]
    [Route("/login")]
    public IActionResult SignIn()
    {
        return View();
    }


    [HttpPost]
    [Route("/login")]
    public async Task<IActionResult> SignIn(SignInViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Home", "Default");
                }
            }
        }
        ViewData["StatusMessage"] = "Incorrect email or password";
        return View(model);
    }

    #endregion


    #region Sign Out

    [HttpGet]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("SignIn", "Authentication");
    }

    #endregion

}


