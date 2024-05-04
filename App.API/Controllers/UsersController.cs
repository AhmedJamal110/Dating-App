using App.API.DataContext;
using App.API.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Authorize]
    public class UsersController : BaseController
    {
        private readonly DataDbContext _context;

        public UsersController( DataDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IReadOnlyList<AppUser>> GetAllUsers()
        {

            var users = _context.Users.ToList();

            if (users is null)
                return NotFound();

            return Ok(users);
        }


        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUserById( int id)
        {

            var user = _context.Users.Find(id);

            if (user is null)
                return NotFound();

            return Ok(user);
        }



    }
}
