using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bot.Clients;
using Bot.Dota2;
using Bot.Models;
using Bot.Response;
using Microsoft.Extensions.Logging;
using Amazon.DynamoDBv2.Model;
using System.Collections.Generic;
using Amazon.DynamoDBv2;
using Bot.Extension;
using Bot.Database;
using Microsoft.AspNetCore.Http;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bot.Controllers
{
    [ApiController]
    [Route(@"api/DataBase")]
    public class DatabaseController : Controller
    {
        private readonly IDynamoDBClient _dynamoDbClient;
        private ILogger<DatabaseController> _logger;

        public DatabaseController(ILogger<DatabaseController> logger, IDynamoDBClient dynamoDBClient)
        {
            _logger = logger;
            _dynamoDbClient = dynamoDBClient;


        }
        [HttpGet("player")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetFavoritePlayer([FromQuery]string User)
        {
            var result = await _dynamoDbClient.GetFavoritePlayer(User);
            if (result == null)
                return NotFound("Not found idPlayer");

            var favoriterplayeresponce = new PlayerResponceData
            {
                Name = result.NamePlayer,
                image = result.image_urlPlayer,
                User = User,
                

            };

            return Ok(favoriterplayeresponce);
          
        }
        [HttpGet("team")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFavoriteTeam([FromQuery] string User)
        {
            var result = await _dynamoDbClient.GetFavoriteTeam(User);
            if (result == null)
                return NotFound("Not found idTeam"); ;

            var favoriterteamresponce = new TeamsResponseData
            {
                User=User,
                Name = result.NameTeam,
               image = result.image_urlTeam,
              


            };
            return Ok(favoriterteamresponce);


        }
        [HttpGet("hero")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetFavoriteHero([FromQuery] string User)
        {
            var result = await _dynamoDbClient.GetFavoriteHero(User);
            if (result == null)
                return NotFound("Not found hero");

            var favoriterheroesponce = new HeroResponceData
            {
                name = result.NameHero,
                User = result.User,
                image = result.image_urlHero,
                localized_name = result.Localized_name


            };

            return Ok(favoriterheroesponce);

        }
        [HttpGet("match")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetFavoriteMatch([FromQuery] string User)
        {
            var result = await _dynamoDbClient.GetFavoriteMatch(User);
            if (result == null)
                return NotFound("Not found match");

            var favoritematchesponce = new MatchesResponce
            {
                Name = result.Name,
                User = result.User,
                Begin_at = result.Begin_at,
                id = result.id
                
                


            };

            return Ok(favoritematchesponce);

        }
        [HttpPost("add/player")]
        public async Task<IActionResult> AddPlayerToFavorite([FromQuery] PlayerResponceData playerResponce)
        {
            var data = new PlayerResponceData
            {
                Name = playerResponce.Name,
                
                User=playerResponce.User,
                image=playerResponce.image
            };
            var result =await _dynamoDbClient.PostPlayerToOb(data);

            if (result == false)
            {
                return BadRequest("Cannot insert to database");
            }
            return Ok("Successful have been added");
        }
        [HttpPost("add/hero")]
        public async Task<IActionResult> AddHeroToFavorite([FromQuery] HeroResponceData heroResponce)
        {
            var data = new HeroResponceData
            {
                name = heroResponce.name,
                localized_name=heroResponce.localized_name,
                User = heroResponce.User,
                image = heroResponce.image
            };
            var result = await _dynamoDbClient.PostHeroToOb(data);

            if (result == false)
            {
                return BadRequest("Cannot insert to database");
            }
            return Ok("Successful have been added");
        }
        [HttpPost("add/team")]
        public async Task<IActionResult> AddTeamToFavorite([FromQuery] TeamsResponseData teamsResponse)
        {
            var data = new TeamsResponseData
            {
                Name = teamsResponse.Name,
                
                User = teamsResponse.User,
                image = teamsResponse.image
            };
            var result =await _dynamoDbClient.PostTeamToOb(data);
            if(result==false)
            {
                return BadRequest("Cannot insert to database");
            }
            return Ok("Successful have been added");
        }
        [HttpPost("add/match")]
        public async Task<IActionResult> AddMatchToFavorite([FromQuery] MatchesResponce matchesResponce)
        {
            var data = new MatchesResponce
            {
                User=matchesResponce.User,
                Begin_at=matchesResponce.Begin_at,
                id=matchesResponce.id,
                Name=matchesResponce.Name
            };
            var result = await _dynamoDbClient.PostMatchToOb(data);

            if (result == false)
            {
                return BadRequest("Cannot insert to database");
            }
            return Ok("Successful have been added");
        }

    }
}
