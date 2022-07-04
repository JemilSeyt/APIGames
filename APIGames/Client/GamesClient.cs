using APIGames.Model;
using Newtonsoft.Json.Linq;

namespace APIGames.Client
{
    public class GamesClient
    {

        List<string> keys = new List<string>()
        {
            "346110", "268910", "1085660", "289070", "227300", "489830", "294100", "377160", "1158310", "594650", };

        static string _address = "https://steam-store-data.p.rapidapi.com/api/appdetails/?appids=";
        static string _host = "steam-store-data.p.rapidapi.com";
        static string _apikey = "3e449fa41fmsh149922384a7e9b6p161b61jsncbd5fa838d79";

        public async Task<List<GamesInform>> GameList()
        {
            if (SomeLists.Lists.GameBaseList.Count == 0)
            {
                foreach (var key in keys)
                {
                    var client = new HttpClient();
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(_address + key),
                        Headers =
                        {
                            { "X-RapidAPI-Host", _host + key},
                            { "X-RapidAPI-Key", _apikey },
                        },
                    };
                    var response = await client.SendAsync(request);
                    var body = await response.Content.ReadAsStringAsync();

                    var details = JObject.Parse(body);
                    var result = details[key]?.ToObject<GamesInform>();
                    if (result != null)
                    {
                        result.Data.Id = Convert.ToInt32(key);
                        result.Data.Pc_Requirements?.Parser();
                        SomeLists.Lists.GameBaseList.Add(result);
                    }
                }
            }
            return SomeLists.Lists.GameBaseList;
        }


        public async Task<GamesInform> GameInformationById()
        {
            StreamReader _reader = new StreamReader("D:\\KEY.txt");
            string key = _reader.ReadToEnd();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_address + key),
                Headers =
                {
                    { "X-RapidAPI-Host", _host + key},
                    { "X-RapidAPI-Key", _apikey },
                },
            };
            var response = await client.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            var details = JObject.Parse(body);
            var result = details[key]?.ToObject<GamesInform>();
            if (result != null)
            {
                result.Data.Id = Convert.ToInt32(key);
                result.Data?.Pc_Requirements?.Parser();
                return result;
            }
            else return null;
        }

        public async Task<bool> Postcomment()
        {

            StreamReader _reader = new StreamReader("D:\\Comm.txt");
            string comm = _reader.ReadToEnd();

            using (StreamWriter writer = new StreamWriter("D:\\Comments.txt", true))
            {
                writer.WriteLineAsync(comm);
            }

            return true;

        }
        public string Putcomment()
        {

            StreamReader _reader = new StreamReader("D:\\Comm.txt");
            string comm = _reader.ReadToEnd();

            using (StreamWriter writer = new StreamWriter("D:\\Comments.txt", false))
            {
                writer.WriteLineAsync(comm);
            }

            return comm;
        }

        public async Task<bool> Deletecomments()
        {

            using (StreamWriter writer = new StreamWriter("D:\\Comments.txt", false))
            {
                await writer.WriteLineAsync();
            }
            return true;
        }

    }
}
