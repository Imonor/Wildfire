using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wildfire.Controllers
{
    [Route("api/wildfire")]
    [ApiController]
    public class SimulatorController : ControllerBase
    {
        private const string SimulationDataFile = "SimulationData\\data.json";


        // GET: api/wildfire
        [HttpGet]
        public IEnumerable<string> Get()
        {
            string dataString = System.IO.File.ReadAllText(SimulationDataFile);
            List<string> data = JsonSerializer.Deserialize<List<string>>(dataString).ToList();

            return data;
        }

        // GET: api/wildfire/time
        [HttpGet("time")]
        public int GetTime()
        {
            string dataString = System.IO.File.ReadAllText(SimulationDataFile);
            List<string> data = JsonSerializer.Deserialize<List<string>>(dataString).ToList();

            return data.Count - 1;
        }

        // GET api/wildfire/5
        [HttpGet("{time}")]
        public string Get(int time)
        {
            string dataString = System.IO.File.ReadAllText(SimulationDataFile);
            List<string> data = JsonSerializer.Deserialize<List<string>>(dataString);
            if (time < 0 || time >= data.Count)
                return "Incorrect Time. The Maximum for this simulation is " + (data.Count - 1) + "\n";

            return data[time];
        }

    }
}
