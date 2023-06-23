using Bll;
using Microsoft.AspNetCore.Mvc;
using System;
using WaterPOC.Repository;
using WaterPOC.Repository.Models;

namespace WebApplicationT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WaterController : ControllerBase
    {

        private readonly IBllFacade _bll;

        public WaterController(IBllFacade bll)
        {
            _bll = bll;

        }

        //use IActionResult, more extensibility--DONE
        [HttpGet("getWaterLogs")]
        public IActionResult GetAllWaterLogs()
        {
            //dont just return result implicitly as json, --DONE
            var featureList = _bll.GetAllWaterLogs();

            if (featureList == null)
            {
                return NotFound("Invalid ID");
            }

            return Ok(featureList);
;
        }//put ok

        //normally, type not specified, 
        [HttpGet("getWater/{id:int}/")]
        //[HttpGet("getWater/{featureName}")]
        //[HttpGet("getWater/{locationDescription}")]
        //[HttpGet("getWater/{id:int}/{featureName}")]
        //[HttpGet("getWater/{id:int}/{locationDescription}")]
        //[HttpGet("getWater/{featureName}/{locationDescription}")]
       // [HttpGet("getWater/{id:int}/{featureName}/{locationDescription}")]//understand annotations more, pass route in httpget --DONE
        //pass parameter not as url parameters, rest--DONE
        public IActionResult GetWaterLog(int id, string? featureName=null, string? locationDescription = null)
        {

            var feature =  _bll.GetWaterLog(id, featureName, locationDescription);

            if (feature == null)
            {
                return NotFound("Invalid ID");
            }

            return Ok(feature);
        }




        //always return a response

        //dont show unfinished code to vito

    }
}   