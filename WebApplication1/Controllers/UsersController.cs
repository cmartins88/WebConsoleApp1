using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly APIContext _context;
        
        public UsersController(APIContext context)
        {
            _context = context;
        }

        // GET: /api/users/ID
        [HttpGet("{id}")]
        public ActionResult<User> Details(Guid id)
        {
            try
            {
                var user = 
                    from _user in _context.Users
                    where _user.UserId == id
                    select _user;

                if(user == null || user.Count() != 1)
                {
                    return NotFound(id);
                }

                return user.First();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: /api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> Details()
        {
           return _context.Users;
        }

        // http 200
        // POST: UsersController/Create
        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            try
            {
                var _user = _context.Users.Add(user);
                _context.SaveChanges();
                return _user.Entity;
            } catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: UsersController/Edit/5
        [HttpPut("{id}")]
        public ActionResult<User> Edit(Guid id, User user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            throw new NotImplementedException();
        }

        // GET: UsersController/Delete/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            UsersData.Delete(id);
        }
    }
}
