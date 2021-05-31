using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bot;
using Telegram.Bot;
using Telegram.Bot.Types;




namespace  Bot.Controllers
{
    [Route("api")]
[ApiController]
    public class HomeController : Controller
    {

        
        string img = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fpicsart.com%2Fi%2F328293073115211&psig=AOvVaw2B-kKD6JXDfClRLdQXDITF&ust=1622216857070000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCLjRze-a6vACFQAAAAAdAAAAABAD";
        [HttpGet]
        public string Index() => "MyApi\n"+img;
       
        
        
    }
}