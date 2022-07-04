using Microsoft.AspNetCore.Mvc;
using APIGames.Model;
using APIGames.Client;

namespace APIGames.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PutComment : Controller
    {
        [HttpPut(Name = "PutComment")]
        public async Task Putcomment()
        {
            GamesClient client = new GamesClient();
            var res = client.Putcomment();
        }

    }
}
