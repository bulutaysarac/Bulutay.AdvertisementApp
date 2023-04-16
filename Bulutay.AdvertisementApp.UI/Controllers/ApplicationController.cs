using AutoMapper;
using Bulutay.AdvertisementApp.Business.Interfaces;
using Bulutay.AdvertisementApp.Common.Enums;
using Bulutay.AdvertisementApp.Dtos;
using Bulutay.AdvertisementApp.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Bulutay.AdvertisementApp.UI.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IAdvertisementAppUserService _advertisementAppUserService;
        private readonly IMapper _mapper;

        public ApplicationController(IAppUserService appUserService, IAdvertisementAppUserService advertisementappUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _advertisementAppUserService = advertisementappUserService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Send(int advertisementId)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            await SetUserGenderToViewBag(userId);
            SetMilitaryStatusListToViewBag();

            return View(new AdvertisementAppUserCreateModel()
            {
                AdvertisementId = advertisementId,
                AppUserId = userId,
            });
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        public async Task<IActionResult> Send(AdvertisementAppUserCreateModel model)
        {
            AdvertisementAppUserCreateDto dto = _mapper.Map<AdvertisementAppUserCreateDto>(model);
            if (model.CvFile != null)
            {
                var fileName = Guid.NewGuid().ToString();
                var extName = Path.GetExtension(model.CvFile.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CvFiles", fileName + extName);
                var stream = new FileStream(path, FileMode.Create);
                await model.CvFile.CopyToAsync(stream);
                dto.CvPath = path;
            }

            var response = await _advertisementAppUserService.CreateAsync(dto);
            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var error in response.ValidationErrors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                await SetUserGenderToViewBag(response.Data.AppUserId);
                SetMilitaryStatusListToViewBag();
                return View(model);
            }
            else
            {
                return RedirectToAction("HumanResource", "Home");
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> List()
        {
            var list = await _advertisementAppUserService.GetList(AdvertisementAppUserStatusType.Applied);
            return View(list);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SetStatus(int advertisementAppUserId, AdvertisementAppUserStatusType type, string path = "List")
        {
            await _advertisementAppUserService.SetStatusAsync(advertisementAppUserId, type);
            return RedirectToAction(path);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApprovedList()
        {
            var list = await _advertisementAppUserService.GetList(AdvertisementAppUserStatusType.CalledForInterview);
            return View(list);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RejectedList()
        {
            var list = await _advertisementAppUserService.GetList(AdvertisementAppUserStatusType.Negative);
            return View(list);
        }

        private async Task<int> SetUserGenderToViewBag(int userId)
        {
            var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(userId);
            var user = userResponse.Data;
            ViewBag.GenderId = user.GenderId;
            return userId;
        }

        private void SetMilitaryStatusListToViewBag()
        {
            var militaryEnums = Enum.GetValues(typeof(MilitaryStatusType));
            var militaryStatusList = new List<MilitaryStatusListDto>();
            foreach (var militaryEnum in militaryEnums)
            {
                militaryStatusList.Add(new MilitaryStatusListDto()
                {
                    Id = (int)militaryEnum,
                    Definition = militaryEnum.ToString(),
                });
            }

            ViewBag.MilitaryStatusList = militaryStatusList;
        }
    }
}
