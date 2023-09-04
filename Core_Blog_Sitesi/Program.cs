using DataLayer.Context;
using DataLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ServiceLayer.Extensions;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
//Assembly kodu eklemek.
var assembly = Assembly.GetExecutingAssembly().FullName;

builder.Services.LoadDataLayerExtension(builder.Configuration);  //Extension tanýmlamasý
builder.Services.LoadServiceLayerExtension(); //Extension tanýmlamasý.
builder.Services.AddSession();

//Identity conf.
builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
})
    .AddRoleManager<RoleManager<AppRole>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

//Cookie conf.
builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Admin/Authentication/Login");
    config.LogoutPath = new PathString("/Admin/Authentication/LogOut");
    config.Cookie = new CookieBuilder
    {
        Name = "BlogSite",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest //Always
    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan= TimeSpan.FromDays(1);
    config.AccessDeniedPath = new PathString("/Admin/Authentication/AccessDenied");
});


// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();
app.UseAuthentication(); 
app.UseAuthorization();    //Authenticationun altýnda kalmasý gerekli.

//Area Yönlendirmesi
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Name}/{action=Index}/{id?}");
    endpoints.MapDefaultControllerRoute();
});

app.Run();
