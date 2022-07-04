using Microsoft.AspNetCore.Mvc;
using APIGames.Model;
using APIGames.Client;

namespace APIGames.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GamesList : ControllerBase
    {
        [HttpGet(Name = "GGameList")]
        public async Task<ActionResult<List<APIGames.Model.GamesInform>>> GameList()
        {
            GamesClient client = new GamesClient();
            var res = await client.GameList();
            return Ok(res);
        }

    }
}
