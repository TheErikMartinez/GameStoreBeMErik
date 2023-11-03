using GameStoreBeMErik.Context;
using GameStoreBeMErik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStoreBeMErik.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoGameUserController : ControllerBase
    {
        private GameStoreContext _gameStoreContext;

        public VideoGameUserController(GameStoreContext GameStoreContext)
        {
            _gameStoreContext = GameStoreContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetVideoGameUsers()
        {
            return Ok(await _gameStoreContext.VideoGameUsers.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideoGameUser(VideoGameUser gameUser)
        {
            await _gameStoreContext.VideoGameUsers.AddAsync(gameUser);
            await _gameStoreContext.SaveChangesAsync();
            return Ok(new { message = "Game User created" });
        }
    }
}
