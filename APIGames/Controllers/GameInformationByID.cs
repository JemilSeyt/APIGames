using Microsoft.AspNetCore.Mvc;
using APIGames.Model;
using APIGames.Client;

namespace APIGames.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameInformationByID : Controller
    {
        [HttpGet(Name = "GGameById")]
        public async Task<ActionResult<GamesInform>> GameInformationById()
        {
            GamesClient client = new GamesClient();
            var res = await client.GameInformationById();
            return Ok(res);
        }
    }
}
