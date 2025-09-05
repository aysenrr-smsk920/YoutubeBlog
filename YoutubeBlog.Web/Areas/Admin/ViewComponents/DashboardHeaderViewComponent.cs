using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using YoutubeBlog.Entity.DTOs.Users;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Web.Areas.Admin.ViewComponents
{
    public class DashboardHeaderViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;

        public DashboardHeaderViewComponent(UserManager<AppUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User);
            if (loggedInUser == null)
            {
                // Kullanıcı oturum açmamışsa veya bulunamazsa
                // Güvenli bir şekilde bir sonuç döndürün.
                // Örneğin, boş bir ViewComponent sonucu veya bir hata mesajı.
                return Content("Kullanıcı bilgisi bulunamadı.");
            }
            var map = mapper.Map<UserDTO>(loggedInUser);

            var role = string.Join("", await userManager.GetRolesAsync(loggedInUser));
            map.Role = role;

            return View(map);
        }
    }
}
