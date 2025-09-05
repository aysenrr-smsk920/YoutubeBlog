using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.ComponentModel;
using System.Data;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Articles;
using YoutubeBlog.Entity.DTOs.Users;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Entity.Enums;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Helpers.Images;
using YoutubeBlog.Service.Services.Abstraction;
using YoutubeBlog.Web.ResultMessages;
using static YoutubeBlog.Web.ResultMessages.Messages;

namespace YoutubeBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {

        private readonly IMapper mapper;
        private readonly IToastNotification toast;
        private readonly IUserService userService;
        private readonly IValidator<AppUser> validator;

        public UserController(IMapper mapper, IUserService userService, IValidator<AppUser> validator, IToastNotification toast)
        {
            this.userService = userService;
            this.validator = validator;
            this.mapper = mapper;
            this.toast = toast;
        }
        public async Task<IActionResult> Index()
        {
            var result = await userService.GetAllUserWithRole();
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await userService.GetAllRolesAsync();
            return View(new UserAddDTO { Roles = roles });
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserAddDTO userAddDTO)
        {
            var map = mapper.Map<AppUser>(userAddDTO);
            var validation = await validator.ValidateAsync(map);
            var roles = await userService.GetAllRolesAsync();

            if (ModelState.IsValid)
            {
                var result = await userService.CreateUserAsync(userAddDTO);
                if (result.Succeeded)
                {
                    toast.AddSuccessToastMessage(Messages.User.Add(userAddDTO.Email), new ToastrOptions { Title = "Başarılı" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    result.AddToIdentityModelState(this.ModelState);
                    validation.AddToModelState(this.ModelState);
                    return View(new UserAddDTO { Roles = roles });
                }
            }
            return View(new UserAddDTO { Roles = roles });
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await userService.GetAppUserByIdAsync(userId);

            var roles = await userService.GetAllRolesAsync();

            var map = mapper.Map<UserUpdateDTO>(user);
            map.Roles = roles;
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDTO userUpdateDTO)
        {
            var user = await userService.GetAppUserByIdAsync(userUpdateDTO.Id);
            if (user != null)
            {
                var roles = await userService.GetAllRolesAsync();

                if (ModelState.IsValid)
                {
                    var map = mapper.Map(userUpdateDTO, user);
                    var validation = await validator.ValidateAsync(map);

                    if (validation.IsValid)
                    {
                        user.UserName = userUpdateDTO.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString();
                        var result = await userService.UpdateUserAsync(userUpdateDTO);
                        if (result.Succeeded)
                        {
                            toast.AddSuccessToastMessage(Messages.User.Update(userUpdateDTO.Email), new ToastrOptions { Title = "Başarılı" });
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            result.AddToIdentityModelState(this.ModelState);
                            return View(new UserUpdateDTO { Roles = roles });
                        }
                    }
                    else
                    {
                        validation.AddToModelState(this.ModelState);
                        return View(new UserUpdateDTO { Roles = roles });
                    }

                }
            }
            return NotFound();
        }
        public async Task<IActionResult> Delete(Guid userId)
        {
            var result = await userService.DeleteUserAsync(userId);

            if (result.identityResult.Succeeded)
            {
                toast.AddSuccessToastMessage(Messages.User.Delete(result.email), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                result.identityResult.AddToIdentityModelState(this.ModelState);
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var profile = await userService.GetUserProfileAsync();
            return View(profile);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileDTO userProfileDTO)
        {

            if (ModelState.IsValid)
            {
                var result = await userService.UserProfileUpdateAsync(userProfileDTO);
                if (result)
                {
                    toast.AddSuccessToastMessage("Profil güncelleme işlemi tamamlandı.", new ToastrOptions { Title = "Başarılı" });
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
                else
                {
                    var profile = await userService.GetUserProfileAsync();
                    toast.AddErrorToastMessage("Profil güncelleme işlemi tamamlanmadı. İşlem Başarısız.", new ToastrOptions { Title = "Başarılı" });
                    return View(profile);
                }

            }
            else
                return NotFound();
                
        
        }
    }
}
