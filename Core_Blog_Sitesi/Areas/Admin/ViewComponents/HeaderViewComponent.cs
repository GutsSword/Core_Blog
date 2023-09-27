using AutoMapper;
using EntityLayer.Dtos.Users;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Core_Blog_Sitesi.Areas.Admin.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> userManager;  //Giriş yapacak kullanıcı bilgisini almak için gerekiyor.
        private readonly IMapper mapper;

        public HeaderViewComponent(UserManager<AppUser> userManager , IMapper mapper )
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User);   //Giriş yapan kullanıcının verilerini getirecek.
            var map = mapper.Map<UserDto>(loggedInUser);

            var role = string.Join("", await userManager.GetRolesAsync(loggedInUser));  //Rolu manuel bulduk.
            map.Role = role;

            return View(map);
        }
    }
}
