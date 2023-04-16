using AutoMapper;
using Bulutay.AdvertisementApp.Business.DependencyResolvers.Microsoft;
using Bulutay.AdvertisementApp.Business.Helpers;
using Bulutay.AdvertisementApp.UI.Mappings.AutoMapper;
using Bulutay.AdvertisementApp.UI.Models;
using Bulutay.AdvertisementApp.UI.ValidationRules;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Bulutay.AdvertisementApp.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ValidatorOptions.Global.LanguageManager.Enabled = false;

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddDependencies(builder.Configuration);
            builder.Services.AddTransient<IValidator<AppUserCreateModel>, AppUserCreateModelValidator>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
            {
                opt.Cookie.Name = "Bulutay.AdvertisementApp";
                opt.Cookie.HttpOnly = true;
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.ExpireTimeSpan = TimeSpan.FromDays(10);
                opt.LoginPath = new PathString("/Account/SignIn");
                opt.LogoutPath = new PathString("/Account/LogOut");
                opt.AccessDeniedPath = new PathString("/Account/AccessDenied");
            });

            #region **Mapper**
            var profiles = ProfileHelper.GetProfiles();
            profiles.Add(new AppUserCreateModelProfile());
            profiles.Add(new AdvertisementAppUserCreateModelProfile());
            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfiles(profiles);
            });
            var mapper = configuration.CreateMapper();
            builder.Services.AddSingleton(mapper);
            #endregion **Mapper**

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}