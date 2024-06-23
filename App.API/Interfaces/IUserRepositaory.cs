using App.API.Dtos;
using App.API.Entites;

namespace App.API.Interfaces
{
    public interface IUserRepositaory 
    {
        Task<AppUser> GetUserByIdAsync(int id);

        Task<IReadOnlyList<AppUser>> GetUsersAsync();
        Task Update(AppUser user);
        Task<bool> SaveAllAsync();

        Task<AppUser> GetUSerByUserNameAsync(string userName);



        Task<AppUserDto> GetUserDtoByNameAsync(string userName);

        Task<IReadOnlyList<AppUserDto>> GetUsersDtoAsync();



    }
}
