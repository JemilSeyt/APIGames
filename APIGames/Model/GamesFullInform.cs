using Newtonsoft.Json.Linq;
namespace APIGames.Model;

public class GamesFullInform
{
    public string? Name { get; set; }

    public int Id { get; set; }

    public string? WebSite { get; set; }

    public string Header_Image { get; set; }
    public Requirements? Pc_Requirements { get; set; }

    public Critic? MetaCritic { get; set; }

    public List<Category>? Categories { get; set; }

    public List<Genre>? Genres { get; set; }

    public RecommendationLevel? Recommendations { get; set; }

}