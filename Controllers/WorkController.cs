using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using simpleService.Models;

namespace simpleService.Controllers
{
    [Route("api/[controller]")]
    public class WorkController : ControllerBase
    {
        public WorkController() { }

        // GET api/work
        [HttpGet()]
        [Route("noParameters")]
        public ActionResult<ResultData> NoParameters()
        {
            return new ResultData { ApplicationName = Environment.MachineName, Message = "No parameters" };
        }

        // GET api/work/5
        [HttpGet()]
        [Route("simpleParameters/{applicationName}/{message}")]
        public ActionResult<ResultData> SimpleParameters(string applicationName, string message)
        {
            return new ResultData { ApplicationName = Environment.MachineName, Message = $"{message} from {applicationName}" };
        }

        // POST api/work
        [HttpPost()]
        [Route("complexParameter")]
        public ActionResult<ResultData> ComplexParameter([FromBody]ResultData data) {
            data.ApplicationName = Environment.MachineName;
            data.Message = $"Thanks for sending {data.Message} from {data.ApplicationName}.  Here's a little something for you: {DateTime.Now.ToLongTimeString()}";
            return data;
         }

    }

    public class ResultData
    {
        public string ApplicationName { get; set; }
        public string Message { get; set; }

    }
}