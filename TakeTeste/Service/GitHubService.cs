using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeTeste.Interface;
using TakeTeste.Models;

namespace TakeTeste.Service
{
    public class GitHubService : IGitHubService
    {
        public async Task<List<RepositoriosModel>> GetRepositorios(string Language, string User, int TotalRepos)
        {
            var client = new RestClient($"https://api.github.com/users/{User}/repos?direction=asc&sort=created");
            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            var retorno = JsonConvert.DeserializeObject<List<RepositoriosModel>>(response.Content);

            List<RepositoriosModel> repositorios = new List<RepositoriosModel>();

            foreach (var item in retorno)
            {
                if (item.Language == Language)
                {
                    if (repositorios.Count < TotalRepos)
                    {
                        repositorios.Add(item);
                    }
                }
            }
            return repositorios;
        }
    }
}
