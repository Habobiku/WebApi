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
    [Route(@"api/hero")]
    public class HeroController : Controller
    {


        private ILogger<HeroController> _logger;

        private readonly PandaClient _pandaClient;
        public HeroController(ILogger<HeroController> logger, PandaClient pandaclient)
        {
            _logger = logger;
            _pandaClient = pandaclient;

        }
        [HttpGet]
        public async Task<HeroResponce> GetPlayer([FromQuery] string name)
        {

            var hero = await _pandaClient.GetHero(name);
            if (hero == null)
            {
                var result = new HeroResponce
                {
                    name = "No such hero was found"

                };
                return result;
            }
            else
            {
                var result = new HeroResponce
                {
                    name = hero.name,
                    image = hero.image_url,
                    localized_name = hero.localized_name,



                };


                return result;
            }

        }

    }


}
