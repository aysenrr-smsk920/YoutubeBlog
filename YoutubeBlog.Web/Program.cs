using Microsoft.AspNetCore.Identity;
using NToastNotify;
using YoutubeBlog.Data.Context;
using YoutubeBlog.Data.Extensions;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Describers;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Web.Filters.ArticleVisitors;


var builder = WebApplication.CreateBuilder(args);
//var assembly = Assembly.GetExecutingAssembly().FullName;
builder.Services.LoadDataLayerExtensions(builder.Configuration);
builder.Services.LoadServiceLayerExtensions();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add<ArticleVisitorFilter>();
})
    .AddNToastNotifyToastr(new ToastrOptions()
    {
        PositionClass = ToastPositions.TopRight,
        TimeOut = 3000,
    })
    .AddRazorRuntimeCompilation();


builder.Services.AddIdentity<AppUser, AppRole>(opt => //sýnýflarýmýý ekledim 
{
    //deneme amaçlý yaptýk canlý da bunlar true olmalý
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;

})
    .AddRoleManager<RoleManager<AppRole>>()
    .AddErrorDescriber<CustomIdentityErrorDescriber>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Admin/Auth/Login");
    config.LogoutPath = new PathString("/Admin/Auth/Login");
    config.Cookie = new CookieBuilder
    {
        Name = "YoutubeBlog",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest, // tüm istekleri alabilsin diye ama canlý da always yapýyoruz ki https olanlardan istek gelsin.

    };

    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(7);
    config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied"); //yetkisiz giriþ olduðunda actiona atýcak

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseNToastNotify();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseNToastNotify();
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
     name: "Admin",
     areaName: "Admin",
     pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
     );

    endpoints.MapDefaultControllerRoute();
});

app.Run();
