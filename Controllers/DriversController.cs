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
            var drivers = new List<Driver>
    {
        new Driver
        {
            Driver_Fristname = "amine",
            Driver_Surname = "hammoumi",
            Age = 45
        },
        new Driver
        {
            Driver_Fristname = "sarah",
            Driver_Surname = "bastow",
            Age = 25
        },
        new Driver
        {
            Driver_Fristname = "Medica",
            Driver_Surname = "test",
            Age = 33
        }
    };

            return drivers;
        }


        [HttpPost]
        public void Post(string jsonData)
        {
            var driverInfo = JsonConvert.DeserializeObject<Driver>(jsonData);

            _logger.LogInformation("Driver name: {FirstName} {LastName}, Age: {Age}", driverInfo.Driver_Fristname, driverInfo.Driver_Surname, driverInfo.Age);

            using (var streamWriter = new System.IO.StreamWriter(@"C:\ProjectFile\text.txt", true))
            {
                streamWriter.WriteLine(driverInfo.Driver_Fristname);
                streamWriter.WriteLine(driverInfo.Driver_Surname);
                streamWriter.WriteLine(driverInfo.Age);
            }
        }
    }
}
