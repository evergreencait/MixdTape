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
    [Table("Artists")]
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Track { get; set; }

        public ICollection<PlaylistsTracks> PlaylistsTracks { get; set; }
        public virtual ApplicationUser User { get; set; }

        public static List<Artist> GetArtists()
        {
            var client = new RestClient("http://ws.audioscrobbler.com//2.0/?method=artist.getsimilar&artist=nirvana&api_key=" + EnvironmentVariables.LastFmKey + "&format=json");
            var request = new RestRequest("", Method.GET);
            Console.WriteLine(request);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            Console.WriteLine(jsonResponse);
            string jsonOutput = jsonResponse["similarartists"]["artist"].ToString();
            var artistList = JsonConvert.DeserializeObject<List<Artist>>(jsonOutput);
            Console.WriteLine(artistList[0].Name);
            return artistList;
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