
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;
using YoutubeBlog.Entity.DTOs.Images;
using YoutubeBlog.Service.FluentValidations;
using YoutubeBlog.Service.Helpers.Images;
using YoutubeBlog.Service.Services.Abstraction;
using YoutubeBlog.Service.Services.Concrete;

namespace YoutubeBlog.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDashboardService, DashboardServise>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//kullanıcı bulmak için kullanılıyor değerleri dönücek
            services.AddScoped<IImageHelper, ImageHelper>();
            services.AddAutoMapper(assembly);
            services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
                opt.DisableDataAnnotationsValidation = true;
                opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
            });

            
            return services;
        }
    }
}
