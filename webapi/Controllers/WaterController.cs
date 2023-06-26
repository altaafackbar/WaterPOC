using Azure.Core;
using Bll;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using WaterPOC.Repository;
using WaterPOC.Repository.Models;

namespace webapi.Controllers
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
        
        //[HttpGet("getWater/{id:int}/")]
        //[HttpGet("getWater/{featureName}")]
        //[HttpGet("getWater/{locationDescription}")]
        //[HttpGet("getWater/{id:int}/{featureName}")]
        //[HttpGet("getWater/{id:int}/{locationDescription}")]
        //[HttpGet("getWater/{featureName}/{locationDescription}")]
        [HttpGet("getWater")]//understand annotations more, pass route in httpget --DONE
        //pass parameter not as url parameters, rest--DONE
        public IActionResult GetWaterLog([FromQuery] GetWaterLogQueryObject request)
        {
            Debug.WriteLine("cid is:" + request.id);
            Debug.WriteLine("cfeature is:" + request.featureName);
            Debug.WriteLine("cloca is:" + request.locationDescription);
            var feature =  _bll.GetWaterLog(request.id, request.featureName, request.locationDescription);

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

        //always return a response

        //dont show unfinished code to vito

    }
}   