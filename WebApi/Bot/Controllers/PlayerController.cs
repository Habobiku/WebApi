using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bot.Clients;
using Bot.Dota2;
using Bot.Models;
using Bot.Response;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bot.Controllers
{
    [ApiController]
    [Route(@"api/player")]
    public class PlayerController : Controller
    {
       

            private ILogger<PlayerController> _logger;

            private readonly PandaClient _pandaClient;
            public PlayerController(ILogger<PlayerController> logger, PandaClient pandaclient)
            {
                _logger = logger;
                _pandaClient = pandaclient;

            }
        [HttpGet]
        public async Task<PlayerResponce> GetPlayer([FromQuery] string name)
        {

            var player = await _pandaClient.GetPlayer(name);
            if (player == null)
            {
                var result = new PlayerResponce
                {
                    Name = "No such player was found"
                    
                };
                return result;
            }
            else
            {
                var result = new PlayerResponce
                {
                    Name = player.name,
                    image = player.image_url,



                };


                return result;
            }

        }

    }

    
}
