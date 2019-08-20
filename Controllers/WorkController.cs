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
                //Force commit
            string header = Request.Headers.ContainsKey("XDemo") ? Request.Headers["XDemo"][0] : "";
            return new ResultData { ApplicationName = Environment.MachineName, Message = "No parameters", Header = header };
        }

        // GET api/work/5
        [HttpGet()]
        [Route("simpleParameters/{applicationName}/{message}")]
        public ActionResult<ResultData> SimpleParameters(string applicationName, string message)
        {
            string header = Request.Headers.ContainsKey("XDemo") ? Request.Headers["XDemo"][0] : "";
            return new ResultData { ApplicationName = Environment.MachineName, Message = $"{message} from {applicationName}", Header=header };
        }

        // POST api/work
        [HttpPost()]
        [Route("complexParameter")]
        public ActionResult<ResultData> ComplexParameter([FromBody]ResultData data) {
            data.Header = Request.Headers.ContainsKey("XDemo") ? Request.Headers["XDemo"][0] : "";
            data.ApplicationName = Environment.MachineName;
            data.Message = $"Thanks for sending {data.Message} from {data.ApplicationName}.  Here's a little something for you: {DateTime.Now.ToLongTimeString()}";
            return data;
         }

    }

    public class ResultData
    {
        public string ApplicationName { get; set; }
        public string Message { get; set; }
        public string Header { get; set; }

    }
}