using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Services.Abstraction;

namespace YoutubeBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IArticleService articleServise;
        private readonly IDashboardService dashboardServise;

        public HomeController(IArticleService articleService, IDashboardService dashboardServise)
       {
            this.articleServise = articleService;
            this.dashboardServise = dashboardServise;
        }
        
        public async Task<IActionResult> Index()
        {
            var articles = await articleServise.GetAllArticlesWithCategoryNonDeletedAsync();
            var result = await dashboardServise.GetYearlyArticleCounts();
            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> YearlyArticleCount()
        {
            var count = await dashboardServise.GetYearlyArticleCounts();
            return Json(JsonConvert.SerializeObject(count)); //liste kullandığımızdan serialize kullanmıyoruz 
           
        }
        [HttpGet]
        public async Task<IActionResult> TotalArticleCount()
        {
            var count = await dashboardServise.GetTotalArticleCount();
            return Json(count);
           
        }
        [HttpGet]
        public async Task<IActionResult> TotalCategoryCount()
        {
            var count = await dashboardServise.GetTotalCategoryCount();
            return Json(count);

        }
    }
}
