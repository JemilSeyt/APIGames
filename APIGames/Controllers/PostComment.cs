using Microsoft.AspNetCore.Mvc;
using APIGames.Model;
using APIGames.Client;

namespace APIGames.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PostComment : Controller
    {
        [HttpPost(Name = "PostComment")]
        public async Task Postcomment()
        {
            GamesClient client = new GamesClient();
            var res = await client.Postcomment();
        }

    }
}
