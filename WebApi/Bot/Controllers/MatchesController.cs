using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bot.Clients;
using Bot.Dota2;
using Bot.Models;
using Bot.Response;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bot.Controllers
{
    [ApiController]
    [Route(@"api/matches")]
    public class MatchesController : Controller
    {


        private ILogger<MatchesController> _logger;

        private readonly PandaClient _pandaClient;
        public MatchesController(ILogger<MatchesController> logger, PandaClient pandaclient)
        {
            _logger = logger;
            _pandaClient = pandaclient;

        }
        [HttpGet]
        public async Task<List<matches>> GetTournamet()
        {

            var matches = await _pandaClient.GetTournamet();
            if(matches==null)
            {
                matches = null;
                
            }




            //    };


            //    return result;
            return matches;
        }
        [HttpGet("id")]

        public async Task<matches> GetTournametById([FromQuery] string id)
        {

            var matches = await _pandaClient.GetTournametById(id);
            if (matches == null)
            {
                var matchesnull = new matches
                {
                    name = "No such match was found"

                };
                return matchesnull;
            }




            //    };


            //    return result;
            return matches;
        }

    }

}



