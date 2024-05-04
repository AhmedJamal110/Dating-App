using App.API.DataContext;
using App.API.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataDbContext _context;

        public UsersController( DataDbContext context)
        {
            _context = context;
        }


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
