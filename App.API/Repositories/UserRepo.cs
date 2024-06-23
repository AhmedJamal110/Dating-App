using App.API.DataContext;
using App.API.Dtos;
using App.API.Entites;
using App.API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace App.API.Repositories
{
    public class UserRepo : IUserRepositaory
    {
        private readonly DataDbContext _context;
        private readonly IMapper _mapper;

        public UserRepo(DataDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUSerByUserNameAsync(string userName)
        {
            return await _context.Users.Include(U => U.Photos).SingleOrDefaultAsync(U => U.UserName == userName);
        }

        public async  Task<AppUserDto> GetUserDtoByNameAsync(string userName)
        {
            return await _context.Users.Where(U => U.UserName == userName)
                .ProjectTo<AppUserDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
            
        }

        public async Task<IReadOnlyList<AppUser>> GetUsersAsync()
        {
            return await _context.Users.Include(U=> U.Photos).ToListAsync();
        }

        public async Task<IReadOnlyList<AppUserDto>> GetUsersDtoAsync()
        {
            return await  _context.Users.
                ProjectTo<AppUserDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async  Task<bool> SaveAllAsync()
        {
          return  await _context.SaveChangesAsync() > 0;           
        }

        public async Task Update(AppUser user)
        {
             _context.Users.Update(user);
        }
    }
}
