using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class WeatherForecastController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post([FromBody] TTN ttn)
        {
            Success output = new Success();
            output.Stage(ttn.Sentence);
            return Ok(output);
        }
    }
}
  
