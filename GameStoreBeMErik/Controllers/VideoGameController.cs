using GameStoreBeMErik.Context;
using GameStoreBeMErik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace GameStoreBeMErik.Controllers
{

        [ApiController]
        [Route("api/[controller]")]
        public class VideoGameController : ControllerBase
        {
            private GameStoreContext _gameStoreContext;

            public VideoGameController(GameStoreContext GameStoreContext)
            {
                _gameStoreContext = GameStoreContext;
            }

            [HttpGet]
            public async Task<IActionResult> GetVideoGames()
            {
                return Ok(await _gameStoreContext.VideoGames.ToListAsync());
            }

            [HttpPost]
            public async Task<IActionResult> CreateVideoGame(VideoGame game)
            {
                await _gameStoreContext.VideoGames.AddAsync(game);
                await _gameStoreContext.SaveChangesAsync();
                return Ok(new { message = "Game created" });
            }

            [HttpGet]
            [Route("{id:int}")]
            public async Task<IActionResult> GetVideoGame([FromRoute] int id)
            {
                var game = await _gameStoreContext.VideoGames.FindAsync(id);
                if (game == null)
                {
                    return NotFound();
                }
                return Ok(game);
            }

            [HttpPut]
            [Route("{id:int}")]
            public async Task<IActionResult> UpdateVideoGame([FromRoute] int id, VideoGame game)
            {
                var newGame = await _gameStoreContext.VideoGames.FindAsync(id);
                if (newGame != null)
                {
                    newGame.Title = game.Title;
                    newGame.Description = game.Description;
                    newGame.Type = game.Type;
                    newGame.Price = game.Price;
                    newGame.Rating = game.Rating;
                await _gameStoreContext.SaveChangesAsync();
                    return Ok(newGame);
                }
                return NotFound();
            }

            [HttpDelete]
            [Route("{id:int}")]
            public async Task<IActionResult> DeleteVideoGame(int id)
            {
                var game = await _gameStoreContext.VideoGames.FindAsync(id);
                if (game != null)
                {
                    _gameStoreContext.Remove(game);
                    _gameStoreContext.SaveChanges();
                    return Ok(game);
                }
                return NotFound();
            }
        }
}

