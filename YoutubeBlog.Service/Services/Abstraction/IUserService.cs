using Microsoft.AspNetCore.Identity;
using YoutubeBlog.Entity.DTOs.Users;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.Services.Abstraction
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUserWithRole();
        Task<List<AppRole>> GetAllRolesAsync();
        Task<IdentityResult> CreateUserAsync(UserAddDTO userAddDTO);
        Task<IdentityResult> UpdateUserAsync(UserUpdateDTO userUpdateDTO);
        Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId);
        Task<AppUser> GetAppUserByIdAsync(Guid userId);
        Task<string> GetUserRoleAsync(AppUser user);
        Task<UserProfileDTO> GetUserProfileAsync();
        Task<bool> UserProfileUpdateAsync(UserProfileDTO userProfileDTO);
    }
}
