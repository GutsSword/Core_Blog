using AutoMapper;
using Core_Blog_Sitesi.ResultMessages;
using EntityLayer.Dtos.Categories;
using EntityLayer.Dtos.Users;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using ServiceLayer.Services.Concrete;
using System.Data;

namespace Core_Blog_Sitesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IToastNotification toastNotification;

        public UserController(IMapper mapper, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IToastNotification toastNotification)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.toastNotification = toastNotification;
        }
        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();
            var map = mapper.Map<List<UserDto>>(users);

            foreach (var item in map)
            {
                var findUser = await userManager.FindByIdAsync(item.Id.ToString());
                var role = string.Join("", await userManager.GetRolesAsync(findUser));

                item.Role = role;
            }

            return View(map);
        }
        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return View(new UserAddDto { Roles = roles });
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UserAddDto userAddDto)
        {
            var roles = await roleManager.Roles.ToListAsync();
            var map = mapper.Map<AppUser>(userAddDto);

            if (ModelState.IsValid)
            {
                map.UserName = userAddDto.Email;
                var result = await userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
                if (result.Succeeded)
                {
                    var findRole = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                    await userManager.AddToRoleAsync(map, findRole.ToString());
                    toastNotification.AddSuccessToastMessage(Messages.Users.Add(userAddDto.FirstName, userAddDto.LastName), new ToastrOptions { Title = "İşlem Başarılı" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    foreach (var errors in result.Errors)  //Identynin Kendi Hata Sistemi
                    {
                        ModelState.AddModelError("", errors.Description);
                    }
                    return View(new UserAddDto { Roles = roles });
                }
            }
            return View(new UserAddDto { Roles = roles });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            var roles = await roleManager.Roles.ToListAsync();
            var map = mapper.Map<UserUpdateDto>(user);
            map.Roles = roles;

            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserUpdateDto userUpdateDto)
        {
            var user = await userManager.FindByIdAsync(userUpdateDto.Id.ToString());
            if (user != null)
            {
                var userRole = string.Join("", await userManager.GetRolesAsync(user));
                var roles = await roleManager.Roles.ToListAsync();
                if (ModelState.IsValid)
                {
                    mapper.Map(userUpdateDto, user);
                    user.UserName = userUpdateDto.Email;
                    user.SecurityStamp = Guid.NewGuid().ToString(); // ??!??!?
                    var result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        await userManager.RemoveFromRoleAsync(user, userRole);
                        var findRole = await roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
                        await userManager.AddToRoleAsync(user, findRole.Name);
                        toastNotification.AddSuccessToastMessage(Messages.Users.Update(userUpdateDto.FirstName, userUpdateDto.LastName), new ToastrOptions { Title = "İşlem Başarılı." });
                        return RedirectToAction("Index", "User", new { Area = "Admin" });
                    }
                    else
                    {
                        foreach (var errors in result.Errors)  //Identynin Kendi Hata Sistemi
                        {
                            ModelState.AddModelError("", errors.Description);
                        }
                        return View(new UserUpdateDto { Roles = roles });
                    }
                }
            }
            return NotFound();
        }
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            var result = await userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                toastNotification.AddSuccessToastMessage(Messages.Users.Delete(user.FirstName, user.LastName), new ToastrOptions { Title = "İşlem Başarılı." });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                foreach (var errors in result.Errors)  //Identynin Kendi Hata Sistemi
                {
                    ModelState.AddModelError("", errors.Description);
                }
            }
            return NotFound();
        }
    }
}
