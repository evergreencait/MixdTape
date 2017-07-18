using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace MixdTape.Models
{
    [Table("Artists")]
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }

        public ICollection<PlaylistsTracks> PlaylistsTracks { get; set; }
        public virtual ApplicationUser User { get; set; }

        public static List<Artist> GetArtists(string artist)
        {
            var client = new RestClient("http://gruvr.com/feed/?band=elton%20john");
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
            return artistList;
        }


        //public static List<Artist> GetTracks(string clickedArtist)
        //{
        //    var client = new RestClient("http://www.audioscrobbler.com/2.0/?method=artist.gettoptracks&artist=" + clickedArtist+ "&api_key=" + EnvironmentVariables.LastFmKey + "&format=json");
        //    var request = new RestRequest("", Method.GET);
        //    Console.WriteLine(request);
        //    var response = new RestResponse();
        //    Task.Run(async () =>
        //    {
        //        response = await GetResponseContentAsync(client, request) as RestResponse;
        //    }).Wait();
        //    JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
        //    Console.WriteLine("response " + jsonResponse);
        //    string jsonOutput = jsonResponse["toptracks"]["track"].ToString();
        //    var trackList = JsonConvert.DeserializeObject<List<Artist>>(jsonOutput);
        //    Console.WriteLine(trackList[0].Name);
        //    return trackList;
        //}


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