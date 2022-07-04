using Microsoft.AspNetCore.Mvc;
using APIGames.Model;
using APIGames.Client;

namespace APIGames.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class DeleteComments : Controller
    {
        [HttpDelete(Name = "Deletecomments")]
        public async Task Deletecomments()
        {
            GamesClient client = new GamesClient();
            var res = await client.Deletecomments();
        }

    }
}
