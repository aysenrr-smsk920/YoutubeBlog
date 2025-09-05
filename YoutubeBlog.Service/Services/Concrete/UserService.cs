using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Users;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Entity.Enums;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Helpers.Images;
using YoutubeBlog.Service.Services.Abstraction;

namespace YoutubeBlog.Service.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IImageHelper imageHelper;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IImageHelper imageHelper,UserManager<AppUser> userManager, RoleManager<AppRole> roleManager,SignInManager<AppUser> signInManager,IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.imageHelper = imageHelper;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }
        public async Task<List<UserDTO>> GetAllUserWithRole()
        {
            var users = await userManager.Users.ToListAsync();
            var map = mapper.Map<List<UserDTO>>(users);

            foreach (var item in map)
            {
                var findUser = await userManager.FindByIdAsync(item.Id.ToString());
                var role = string.Join("", await userManager.GetRolesAsync(findUser));

                item.Role = role;
            }
            return map;
        }
        public async Task<List<AppRole>> GetAllRolesAsync()
        {
            return await roleManager.Roles.ToListAsync();
        }

        public async Task<IdentityResult> CreateUserAsync(UserAddDTO userAddDTO)
        {
            var map = mapper.Map<AppUser>(userAddDTO);
            map.UserName = userAddDTO.Email;
            var result = await userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDTO.Password) ? "" : userAddDTO.Password);
            if (result.Succeeded)
            {
                var findRole = await roleManager.FindByIdAsync(userAddDTO.RoleId.ToString());
                await userManager.AddToRoleAsync(map, findRole.ToString());
                return result;
            }
            else
                return result;
        }
        public async Task<AppUser> GetAppUserByIdAsync(Guid userId)
        {
            return await userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<IdentityResult> UpdateUserAsync(UserUpdateDTO userUpdateDTO)
        {
            var user = await GetAppUserByIdAsync(userUpdateDTO.Id);
            var userRole = await GetUserRoleAsync(user);
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                await userManager.RemoveFromRoleAsync(user, userRole);
                var findRole = await roleManager.FindByIdAsync(userUpdateDTO.RoleId.ToString());
                await userManager.AddToRoleAsync(user, findRole.Name);
                return result;
            }
            else
                return result;
        }
        public async Task<string> GetUserRoleAsync(AppUser user)
        {
            return string.Join("", await userManager.GetRolesAsync(user));
        }
        public async Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId)
        {
            var user = await GetAppUserByIdAsync(userId);
            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
                return (result, user.Email);
            else
                return (result, null);
        }
        public async Task<UserProfileDTO> GetUserProfileAsync()
        {
            var userId = _user.GetLoggedUserId();
            var getUserWithImage = await unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userId, x => x.Image);
            var map = mapper.Map<UserProfileDTO>(getUserWithImage);
            map.Image.FileName = getUserWithImage.Image.FileName;
            return map;
        }
        private async Task<Guid> UploadImageForUser(UserProfileDTO userProfileDTO)
        {
            var userEmail = _user.GetLoggedUserEmail();
            var imageUpload = await imageHelper.Upload($"{userProfileDTO.FirstName}{userProfileDTO.LastName}", userProfileDTO.Photo, ImageType.User);
            Image image = new(imageUpload.Fullname, userProfileDTO.Photo.ContentType, userEmail);
            await unitOfWork.GetRepository<Image>().AddAsync(image);
            return image.Id;
        }
        public async Task<bool> UserProfileUpdateAsync(UserProfileDTO userProfileDTO)
        {
            var userId = _user.GetLoggedUserId();
            var user = await GetAppUserByIdAsync(userId);

            var isVerified = await userManager.CheckPasswordAsync(user, userProfileDTO.CurrentPassword);
            if (isVerified && userProfileDTO.NewPassword != null)
            {
                var result = await userManager.ChangePasswordAsync(user, userProfileDTO.CurrentPassword, userProfileDTO.NewPassword);
                if (result.Succeeded)
                {
                    await userManager.UpdateSecurityStampAsync(user);
                    await signInManager.SignOutAsync();
                    await signInManager.PasswordSignInAsync(user, userProfileDTO.NewPassword, true, false);

                    mapper.Map(userProfileDTO, user);

                    if(userProfileDTO.Photo != null) 
                    {
                        user.ImageId = await UploadImageForUser(userProfileDTO);
                        
                    }
                    await userManager.UpdateAsync(user);

                    await unitOfWork.SaveAsync();
                    return true;
                }
                else
                    return false;
            }
            else if (isVerified)
            {
                await userManager.UpdateSecurityStampAsync(user);
                mapper.Map(userProfileDTO, user);

                if (userProfileDTO.Photo != null) 
                    user.ImageId = await UploadImageForUser(userProfileDTO);
                   

                await userManager.UpdateAsync(user);
                await unitOfWork.SaveAsync();
                return true;
            }
            else
                return false;
        } 
    }
}
