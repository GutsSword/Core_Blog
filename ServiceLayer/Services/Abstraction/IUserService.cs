using EntityLayer.Dtos.Users;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Abstraction
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersWithRoleAsync();
        Task<List<AppRole>> GetAllRoleAsync();
        Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto);
        Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto);
        Task<(IdentityResult IdentityResult,string? Name, string? LastName)> DeleteUserAsync(Guid userId);   //İsimlendirme yaptık. İsimlendirme olmasaydı item1 ve item2 olarak dönecekti.
        Task<AppUser> GetAppUserByIdAsync(Guid userId);
        Task<string> GetUserRoleAsync(AppUser user);
        Task<UserProfileDto> GetUserProfileAsync();

        Task<bool> UserProfileUpdate(UserProfileDto userProfileDto);
    }
}
