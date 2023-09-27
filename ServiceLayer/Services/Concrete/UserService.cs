using AutoMapper;
using DataLayer.UnitOfWork;
using EntityLayer.Dtos.Users;
using EntityLayer.Entities;
using EntityLayer.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ServiceLayer.Extensions;
using ServiceLayer.Helper.Images;
using ServiceLayer.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitofWork unitofWork;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IImageHelper ımageHelper;
        private readonly ClaimsPrincipal _user;

        public UserService(IUnitofWork unitofWork, IMapper mapper, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IHttpContextAccessor httpContextAccessor, SignInManager<AppUser> signInManager, IImageHelper ımageHelper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.httpContextAccessor = httpContextAccessor;
            this.signInManager = signInManager;
            this.ımageHelper = ımageHelper;
            _user = httpContextAccessor.HttpContext.User;

        }
        public async Task<List<UserDto>> GetAllUsersWithRoleAsync()
        {
            var users = await userManager.Users.ToListAsync();
            var map = mapper.Map<List<UserDto>>(users);

            foreach (var item in map)
            {
                var findUser = await userManager.FindByIdAsync(item.Id.ToString());
                var role = string.Join("", await userManager.GetRolesAsync(findUser));

                item.Role = role;
            }
            return map;
        }

        public async Task<List<AppRole>> GetAllRoleAsync()
        {
            return await roleManager.Roles.ToListAsync();
        }

        public async Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto)
        {
            var map = mapper.Map<AppUser>(userAddDto); //userAddDto' yu AppUser'a çevirir.
            map.UserName = userAddDto.Email;
            var result = await userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
            if (result.Succeeded)
            {
                var findRole = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                await userManager.AddToRoleAsync(map, findRole.ToString());
                return result;
            }
            else
            {
                return result;
            }
        }

        public async Task<AppUser> GetAppUserByIdAsync(Guid userId)
        {
            return await userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto)
        {
            var user = await GetAppUserByIdAsync(userUpdateDto.Id);
            var userRoles = await GetUserRoleAsync(user);


            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                await userManager.RemoveFromRoleAsync(user, userRoles);
                var findRole = await roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
                await userManager.AddToRoleAsync(user, findRole.Name);
                return result;
            }
            else
                return result;
        }

        public async Task<string> GetUserRoleAsync(AppUser user)
        {
            return string.Join("", await userManager.GetRolesAsync(user));
        }

        public async Task<(IdentityResult IdentityResult, string? Name, string? LastName)> DeleteUserAsync(Guid userId)
        {
            var user = await GetAppUserByIdAsync(userId);
            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
                return (result, user.FirstName, user.LastName);
            else
                return (result, null, null);
        }

        public async Task<UserProfileDto> GetUserProfileAsync()
        {
            var userId = _user.GetLoggedInUserId();

            var getUserWithImage = await unitofWork.GetRepository<AppUser>().GetAsync(x => x.Id == userId, x => x.Image);
            var map = mapper.Map<UserProfileDto>(getUserWithImage);
            map.Image.FileName = getUserWithImage.Image.FileName;

            return map;
        }

        private async Task<Guid> UploadImageForUser(UserProfileDto userProfileDto)
        {
            var userMail = _user.GetLoggedInMail();

            var imageUpload = await ımageHelper.Upload($"{userProfileDto.FirstName}{userProfileDto.LastName}", userProfileDto.Photo, ImageType.User); //Image Helper
            Image image = new(imageUpload.FullName, userProfileDto.Photo.ContentType, userMail);//Image Helper
            await unitofWork.GetRepository<Image>().AddAsync(image);

            return image.Id;
        }

        public async Task<bool> UserProfileUpdate(UserProfileDto userProfileDto)
        {
            var userId = _user.GetLoggedInUserId();
            var user = await GetAppUserByIdAsync(userId);  // kullanıcı bilgilerini getirme

            var isVerified = await userManager.CheckPasswordAsync(user, userProfileDto.CurrentPassword); //Identity şifre kontrol etme, bool bir değer döndürecektir
            if (isVerified && userProfileDto.NewPassword != null && userProfileDto.Photo != null)
            {
                var result = await userManager.ChangePasswordAsync(user, userProfileDto.CurrentPassword, userProfileDto.NewPassword);  //Identiy şifre değiştirme 
                if (result.Succeeded)
                {
                    await userManager.UpdateSecurityStampAsync(user);   //security stamp güvenlik damgası gibidir.Güncellenmesi gerekir.
                    await signInManager.SignOutAsync();  //Çıkış yapar.
                    await signInManager.PasswordSignInAsync(user, userProfileDto.NewPassword, true, false);

                    mapper.Map(userProfileDto, user);
                    user.ImageId = await UploadImageForUser(userProfileDto);   
                    
                    await userManager.UpdateAsync(user);
                    await unitofWork.SaveAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (isVerified)
            {
                await userManager.UpdateSecurityStampAsync(user);
                mapper.Map(userProfileDto, user);

                user.ImageId = await UploadImageForUser(userProfileDto);

                await userManager.UpdateAsync(user);
                await unitofWork.SaveAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
    

