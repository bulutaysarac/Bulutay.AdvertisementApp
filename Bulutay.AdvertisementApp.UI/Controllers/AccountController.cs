using AutoMapper;
using Bulutay.AdvertisementApp.Business.Interfaces;
using Bulutay.AdvertisementApp.Common.Enums;
using Bulutay.AdvertisementApp.Dtos;
using Bulutay.AdvertisementApp.UI.Extensions;
using Bulutay.AdvertisementApp.UI.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bulutay.AdvertisementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IValidator<AppUserCreateModel> _appUserCreateModelValidator;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public AccountController(IGenderService genderService, IValidator<AppUserCreateModel> appUserCreateModelValidator, IAppUserService appUserService, IMapper mapper)
        {
            _genderService = genderService;
            _appUserCreateModelValidator = appUserCreateModelValidator;
            _appUserService = appUserService;
            _mapper = mapper;
        }
        public async Task<IActionResult> SignUp()
        {
            var response = await _genderService.GetAllAsync();
            return View(new AppUserCreateModel()
            {
                Genders = response.Data
            });
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(AppUserCreateModel model)
        {
            var response = await _genderService.GetAllAsync();
            model.Genders = response.Data;
            var result = _appUserCreateModelValidator.Validate(model);
            if(result.IsValid)
            {
                var dto = _mapper.Map<AppUserCreateDto>(model);
                var createResponse = await _appUserService.CreateWithRoleAsync(dto, (int)RoleType.Member);
                return this.ResponseRedirectAction(createResponse, "SignIn");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            
            return View(model);
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserSignInDto dto)
        {
            var signInResult = await _appUserService.CheckUser(dto);
            if (signInResult.ResponseType == ResponseType.Success)
            {
                var roleResult = await _appUserService.GetRolesByUserIdAsync(signInResult.Data.Id);
                var claims = new List<Claim>();

                if(roleResult.ResponseType == ResponseType.Success)
                {
                    foreach (var role in roleResult.Data)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Definition));
                    }
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, signInResult.Data.Id.ToString()));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties()
                    {
                        IsPersistent = dto.RememberMe
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToAction("Index", "Home");
                }
            }
            else if(signInResult.ResponseType == ResponseType.NotFound)
            {
                ModelState.AddModelError("Username", "'Username' or 'Password' is incorrect!");
                ModelState.AddModelError("Password", "'Username' or 'Password' is incorrect!");
            }
            else
            {
                foreach (var error in signInResult.ValidationErrors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View(dto);
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
