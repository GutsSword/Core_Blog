using DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly().FullName;

// Add services to the container.
builder.Services.AddControllersWithViews();
//Aþþaðýdaki Kod Bloðu Koleksiyon içine Context sýnýfýný alýr(AppDbContext) ve Parametre olarak DefaultConnection olarak appsetting.json'da
//tanýmlanan yapýyý alýr.
builder.Services.AddDbContext<AppDbContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
