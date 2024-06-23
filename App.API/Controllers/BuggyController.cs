using App.API.DataContext;
using App.API.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class BuggyController : BaseController
    {
        private readonly DataDbContext _context;

        public BuggyController(DataDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "Secret Text";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> NotFound()
        {
            var user = _context.Users.Find(100);

            if (user is null)
                return NotFound();

            return user;
        }

        [HttpGet("server-error")]
        public ActionResult<string> ServerErroe()
        {
            
            
                var user = _context.Users.Find(-1);
             return  user.ToString();
        }

        [HttpGet("bad-request")]
        public ActionResult<string> BadRequest()
        {
            return BadRequest();
        }




    }
}
