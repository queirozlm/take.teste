using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeTeste.Models;

namespace TakeTeste.Interface
{
    public interface IGitHubService
    {
        Task<List<RepositoriosModel>> GetRepositorios(string Language, string User, int TotalRepos);
    }
}
