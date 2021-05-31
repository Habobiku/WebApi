using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bot.Clients;
using Bot.Dota2;
using Bot.Response;
using Bot.Models;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bot.Controllers
{
    [ApiController]
    [Route(@"api/teams")]

    public class TeamsController : Controller
    {
        private ILogger<TeamsController> _logger;

        private readonly PandaClient _pandaClient;
        public TeamsController(ILogger<TeamsController> logger, PandaClient pandaclient)
        {
            _logger = logger;
            _pandaClient = pandaclient;

        }
        [HttpGet]
        public async Task<TeamsResponce> GetTeams([FromQuery] string name)
        {

            var team = await _pandaClient.GetTeam(name);
            if (team == null)
            {
                var result = new TeamsResponce
                {
                    Name = "No such team was found"

                };
                return result;
            }
            else
            {
                var result = new TeamsResponce
                {
                    Name = team.name,
                    image = team.image_url,



                };
                return result;
            }
        }



    }
}

