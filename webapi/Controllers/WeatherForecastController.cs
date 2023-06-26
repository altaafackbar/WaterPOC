using Bll;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IBllFacade _bll;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IBllFacade bll)
    {
        _logger = logger;
        _bll = bll;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("getWater")]//understand annotations more, pass route in httpget --DONE
                         //pass parameter not as url parameters, rest--DONE
    public IActionResult GetWaterLog([FromQuery] GetWaterLogQueryObject request)
    {
        Debug.WriteLine("cid is:" + request.id);
        Debug.WriteLine("cfeature is:" + request.featureName);
        Debug.WriteLine("cloca is:" + request.locationDescription);
        var feature = _bll.GetWaterLog(request.id, request.featureName, request.locationDescription);

        if (feature == null)
        {
            return NotFound("Invalid ID");
        }

        return Ok(feature);
    }


    public class GetWaterLogQueryObject
    {
        public int? id { get; set; }
        public string? featureName { get; set; }
        public string? locationDescription { get; set; }
    }
}
