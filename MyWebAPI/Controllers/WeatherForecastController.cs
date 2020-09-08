using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Greeting;

namespace MyWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

//  [HttpGet("yann/test")]
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class SayHiController : ControllerBase
    {
        // GET: api/SayHi
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "fr", "sp", "jp" };
        }

        // GET: api/SayHi/langCode
        [HttpGet("{langCode}", Name = "Get")]
        public string Get(string langCode)
        {
            Greetings g = new Greetings();
            string res = new string("This is how to say Hello in ");
            switch (langCode)
            {
                case "fr": res += "french : " + g.fr(); break;
                case "sp": res += "spanish : " + g.sp(); break;
                case "jp": res += "japanese : " + g.jp(); break;
                default: break;
            }
            return res;
        }
    }
}
