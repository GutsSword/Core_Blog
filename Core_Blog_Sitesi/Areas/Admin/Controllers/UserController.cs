using AutoMapper;
using Core_Blog_Sitesi.ResultMessages;
using DataLayer.Mapping;
using DataLayer.UnitOfWork;
using EntityLayer.Dtos.Articles;
using EntityLayer.Dtos.Categories;
using EntityLayer.Dtos.Users;
using EntityLayer.Entities;
using EntityLayer.Enums;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using ServiceLayer.Extensions;
using ServiceLayer.Helper.Images;
using ServiceLayer.Services.Abstraction;
using ServiceLayer.Services.Concrete;
using System.Data;

namespace Core_Blog_Sitesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly IToastNotification toastNotification;
        private readonly IValidator<AppUser> validator;

        public UserController(IUserService userService,IMapper mapper, IToastNotification toastNotification,IValidator<AppUser> validator)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.toastNotification = toastNotification;
            this.validator = validator;
        }
        public async Task<IActionResult> Index()
        {
            var result = await userService.GetAllUsersWithRoleAsync();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            var roles = await userService.GetAllRoleAsync();
            return View(new UserAddDto { Roles = roles });
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UserAddDto userAddDto)
        {
            var roles = await userService.GetAllRoleAsync();
            var map = mapper.Map<AppUser>(userAddDto);
            var validation = await validator.ValidateAsync(map);

            if (ModelState.IsValid)
            {
                var result = await userService.CreateUserAsync(userAddDto);
                if (result.Succeeded)
                {
                    toastNotification.AddSuccessToastMessage(Messages.Users.Add(userAddDto.FirstName, userAddDto.LastName), new ToastrOptions { Title = "İşlem Başarılı" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    result.AddToIdentityModelState(this.ModelState);
                    validation.AddToModelState(this.ModelState);
                    return View(new UserAddDto { Roles = roles });
                }
            }
            return View(new UserAddDto { Roles = roles });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(Guid userId)
        {
            var user = await userService.GetAppUserByIdAsync(userId);
            var roles = await userService.GetAllRoleAsync();

            var map = mapper.Map<UserUpdateDto>(user);
            map.Roles = roles;

            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserUpdateDto userUpdateDto)
        {
            var user = await userService.GetAppUserByIdAsync(userUpdateDto.Id);
            if (user != null)
            {
                var roles = await userService.GetAllRoleAsync();
                if (ModelState.IsValid)
                {
                    var map = mapper.Map(userUpdateDto, user);
                    var validation = await validator.ValidateAsync(map);

                    if(validation.IsValid)
                    {
                        user.UserName = userUpdateDto.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString(); // ??!??!?
                        var result = await userService.UpdateUserAsync(userUpdateDto);
                        if (result.Succeeded)
                        {
                            toastNotification.AddSuccessToastMessage(Messages.Users.Update(userUpdateDto.FirstName, userUpdateDto.LastName), new ToastrOptions { Title = "İşlem Başarılı." });
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            result.AddToIdentityModelState(this.ModelState);
                            return View(new UserUpdateDto { Roles = roles });
                        }
                    }
                    else
                    {
                        validation.AddToModelState(this.ModelState);
                        return View(new UserUpdateDto { Roles = roles });
                    }
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var result = await userService.DeleteUserAsync(userId);

            if (result.IdentityResult.Succeeded)
            {
                toastNotification.AddSuccessToastMessage(Messages.Users.Delete(result.Name,result.LastName), new ToastrOptions { Title = "İşlem Başarılı." });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                result.IdentityResult.AddToIdentityModelState(this.ModelState);
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var profile = await userService.GetUserProfileAsync();
            return View(profile);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileDto userProfileDto)
        {
           if(ModelState.IsValid)
            {
               var result = await userService.UserProfileUpdate(userProfileDto);
                if(result == true)
                {
                    toastNotification.AddSuccessToastMessage("Güncelleme İşlemi Başarılı.", new ToastrOptions { Title = "İşlem Başarılı." });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    var profile = await userService.GetUserProfileAsync();
                    toastNotification.AddErrorToastMessage("Güncelleme İşlemi Başarısız.", new ToastrOptions { Title = "İşlem Başarısız." });
                    return View(profile);
                }
            }
           else
            {
                return NotFound();
            }
        }
    }
}
