using System;
using Bot.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Bot.Dota2;
using System.Collections.Generic;
using System.Linq;

namespace Bot.Clients
{
    public class PandaClient
    {
        readonly HttpClient _client;
        private static  string _adress;
        private static  string _apitoken;

        public PandaClient()
        {
            
            _adress = config.adress;
            
            _apitoken = config.apitoken;
            _client = new HttpClient();
            _client.BaseAddress =new Uri(_adress);
        }
        public async Task<Dota2.player> GetPlayer(string name)
        {
            name = name.First().ToString().ToUpper() + name.Substring(1);
            var response = await _client.GetAsync($"players?filter[name]={name}&token={_apitoken}");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            if (content == "[]")
            {
                return null;
            }
            else
            {
                var result1 = JsonConvert.DeserializeObject<List<Dota2.player>>(content);
                var result = result1[0];

                return result;

            }
        }


        public async Task<teams> GetTeam(string name)
        {

            name = name.First().ToString().ToUpper() + name.Substring(1);
            var response = await _client.GetAsync($"teams/?filter[name]={name}&token={_apitoken}");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;

            if (content == "[]")
            {
                return null;
            }
            else
            {
                var result1 = JsonConvert.DeserializeObject<List<Dota2.teams>>(content);
                var result = result1[0];

                return result;

            }
        }
        public async Task<heroes> GetHero(string name)
        {
            
            name = name.ToString().ToLower();
            var response = await _client.GetAsync($"heroes/{name}?token={_apitoken}");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            
            if (content == "[]")
            {
                return null;
            }
            else
            {
                var result = JsonConvert.DeserializeObject<heroes>(content);
                
                return result;

            }
        }
        public async Task<List<matches>> GetTournamet()
        {

            
            var response = await _client.GetAsync($"matches/upcoming?page[size]=2&token={_apitoken}");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;

            if (content == "[]")
            {
                return null;
            }
            else
            {
                var result = JsonConvert.DeserializeObject<List<matches>>(content);
                
                return result;

            }
        }
        public async Task<matches> GetTournametById(string id)
        {


            var response = await _client.GetAsync($"matches/upcoming?page[size]=2&filter[id]={id}&token={_apitoken}");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;

            if (content == "[]")
            {
                return null;
            }
            else
            {
                var result1 = JsonConvert.DeserializeObject<List<matches>>(content);
                var result = result1[0];

                return result;

            }
        }
    }
}

