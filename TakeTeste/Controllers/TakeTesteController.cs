using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeTeste.Interface;
using TakeTeste.Models;
using TakeTeste.Service;

namespace TakeTeste.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class TakeTesteController : ControllerBase
    {

        private readonly ILogger<TakeTesteController> _logger;

        public TakeTesteController(ILogger<TakeTesteController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// listar informações sobre os 5 repositórios de linguagem C# mais antigos da Take
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var repos = await new GitHubService().GetRepositorios("C#", "takenet", 5);

            return Ok(repos);
        }
    }
}
