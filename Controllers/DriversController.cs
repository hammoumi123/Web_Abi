using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriversController : ControllerBase
    {
       

        private readonly ILogger<DriversController> _logger;

        public DriversController(ILogger<DriversController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Driver> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Driver
            {
              
            })
            .ToArray();
        }

        [HttpPost]
        public void  Post(string jsonData)
        {
            //In Memory.
            var driverInfo = JsonConvert.DeserializeObject<Driver>(jsonData);

            Serilog.Log.Information(driverInfo.Driver_Fristname);
            Serilog.Log.Information(driverInfo.Driver_Surname);
            Serilog.Log.Information(driverInfo.Age.ToString());



            using (var streamWriter = new System.IO.StreamWriter(@"C:\ProjectFile\text.txt", true))
            {
                streamWriter.WriteLine(driverInfo.Driver_Fristname);
                streamWriter.WriteLine(driverInfo.Driver_Surname);
                streamWriter.WriteLine(driverInfo.Age);
            }
         
        }
    }
}
