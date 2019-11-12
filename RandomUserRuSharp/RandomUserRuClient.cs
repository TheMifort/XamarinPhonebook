using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RandomUserRuSharp.Models;
using RestSharp;

namespace RandomUserRuSharp
{
    public class RandomUserRuClient
    {
        private readonly RestClient _client;

        public RandomUserRuClient()
        {
            _client = new RestClient("http://randomuser.ru/");
        }

        public async Task<List<User>> GetRandomUsersAsync(int count)
        {
            var request = new RestRequest("api.json", Method.GET);
            request.AddQueryParameter("results", count.ToString());

            var response = await _client.ExecuteTaskAsync(request);

            return !response.IsSuccessful ? new List<User>() : JsonConvert.DeserializeObject<List<RootObject>>(response.Content).Select(e=>e.User).ToList();
        }
    }
}