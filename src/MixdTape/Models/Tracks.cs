using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace MixdTape.Models
{
    [Table("Tracks")]
    public class Track
    {
        public int TrackId { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public int Length { get; set; }

        public ICollection<PlaylistsTracks> PlaylistsTracks { get; set; }
        public virtual ApplicationUser User { get; set; }

        public static List<String> GetTrack()
        {
            var client = new RestClient("https://api.spotify.com/v1/artists/43ZHCT0cAZBISjO8DG9PnE/related-artists");
            var request = new RestRequest("", Method.GET);
            Console.WriteLine(request);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            Console.WriteLine(jsonResponse);
            var messageList = JsonConvert.DeserializeObject<List<String>>(jsonResponse["genres"].ToString());
            return messageList;
        }

    
        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

    }

}