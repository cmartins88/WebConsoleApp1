using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // GET: /api/users/ID
        [HttpGet("{id}")]
        public ActionResult<User> Details(Guid id)
        {
            try
            {
                User user = UsersData.Get(id);
                if(user == null)
                {
                    return NotFound();
                }

                return user;
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: /api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> Details()
        {
           return UsersData.GetAll().ToList();
        }

        // POST: UsersController/Create
        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            try
            {
                return UserManager.createUser(user);
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
