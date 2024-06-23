using App.API.DataContext;
using App.API.Dtos;
using App.API.Entites;
using App.API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    //[Authorize]
    public class UsersController : BaseController
    {
        private readonly IUserRepositaory _userRepositaory;
        private readonly IMapper _mapper;

        public UsersController( IUserRepositaory userRepositaory , IMapper mapper)
        {
            _userRepositaory = userRepositaory;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUserDto>>> GetAllUsers()
        {
            var users = await _userRepositaory.GetUsersDtoAsync();
            if (users is null)
                return NotFound();

            var usersDto = _mapper.Map<IReadOnlyList<AppUserDto>>(users);

        

            return Ok(usersDto);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AppUserDto>> GetUserById( int id)
        {

            var user = await _userRepositaory.GetUserByIdAsync(id);

            if (user is null)
                return NotFound();

            var userDto = _mapper.Map<AppUserDto>(user);

            return Ok(userDto);
        }

        [HttpGet("name{username}")]
        public async Task<ActionResult<AppUser>> GetUSertByName(string username)
        {


           var user =  await _userRepositaory.GetUserDtoByNameAsync(username);

            if (user is null)
                return NotFound();

            return Ok(user);
        }

    }
}
