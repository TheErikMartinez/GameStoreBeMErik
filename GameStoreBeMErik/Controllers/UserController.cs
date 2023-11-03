using GameStoreBeMErik.Context;
using GameStoreBeMErik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace GameStoreBeMErik.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private GameStoreContext _gameStoreContext;

        public UserController(GameStoreContext GameStoreContext)
        {
            _gameStoreContext = GameStoreContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _gameStoreContext.Users.Include(a => a.VideoGames).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _gameStoreContext.Users.AddAsync(user);
            await _gameStoreContext.SaveChangesAsync();
            return Ok(new { message = "User created" });
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            var user = await _gameStoreContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, User user)
        {
            var newUser = await _gameStoreContext.Users.FindAsync(id);
            if (newUser != null)
            {
                newUser.Email = user.Email;
                newUser.PasswordHash = user.PasswordHash;
                await _gameStoreContext.SaveChangesAsync();
                return Ok(newUser);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _gameStoreContext.Users.FindAsync(id);
            if (user != null)
            {
                _gameStoreContext.Remove(user);
                _gameStoreContext.SaveChanges();
                return Ok(user);
            }
            return NotFound();
        }
    }
}
