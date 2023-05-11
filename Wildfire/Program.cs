using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Wildfire.Entities;

namespace Wildfire
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string fileName = "Config\\config.json";
            string jsonString = File.ReadAllText(fileName);

            try
            {
                Config config = JsonSerializer.Deserialize<Config>(jsonString);
                Simulator simulator = new Simulator(config);

                simulator.StartSimulation();

                string dataString = File.ReadAllText("SimulationData\\data.json");
                List<string> data = JsonSerializer.Deserialize<List<string>>(dataString);
                foreach (var str in data)
                {
                    Console.WriteLine(str);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: Bad Configuration File.");
                Console.WriteLine(ex.Message);
            }

            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
