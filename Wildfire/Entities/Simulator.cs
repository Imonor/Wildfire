using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Wildfire.Entities
{
    public class Simulator
    {
        private static readonly Random rand = new Random();
        private const string SimulationDataFile = "SimulationData\\data.json";

        public Forest Forest { get; set; }
        public double FireProba { get; set; }
        public List<Coords> FireCells { get; set; }

        public Simulator(Config config)
        {
            if (config.Height > 0 && config.Length > 0)
                Forest = new Forest(config.Height, config.Length, config.FireCells);
            else
                Forest = new Forest();

            FireProba = config.FireProba;
            FireCells = config.FireCells;
        }

        public Simulator(Forest forest, double fireProba, List<Coords> fireCells)
        {
            Forest = forest;
            FireProba = fireProba;
            FireCells = fireCells;
        }

        public void StartSimulation()
        {
            List<string> simulationValue = new List<string>
            {
                Forest.ToString()
            };

            while (FireCells.Count > 0)
            {
                var coordsToFire = new List<Coords>();
                foreach (var fireCell in FireCells)
                {
                    coordsToFire.AddRange(CheckCoordsToFire(fireCell));
                    Forest.AshCell(fireCell);
                }

                FireCells.Clear();

                foreach (var coords in coordsToFire)
                {
                    Forest.FireCell(coords);
                    FireCells.Add(coords);
                }

                simulationValue.Add(Forest.ToString());
            }

            string jsonString = JsonSerializer.Serialize(simulationValue, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            File.WriteAllText(SimulationDataFile, jsonString);
        }

        public List<Coords> CheckCoordsToFire(Coords coords)
        {
            var coordsToFire = new List<Coords>();
            var coordsUp = new Coords { H = coords.H - 1, L = coords.L };
            var coordsDown = new Coords { H = coords.H + 1, L = coords.L };
            var coordsLeft = new Coords { H = coords.H, L = coords.L - 1 };
            var coordsRight = new Coords { H = coords.H, L = coords.L + 1 };



            if (FireCoords(coordsUp))
                coordsToFire.Add(coordsUp);


            if (FireCoords(coordsDown))
                coordsToFire.Add(coordsDown);


            if (FireCoords(coordsLeft))
                coordsToFire.Add(coordsLeft);


            if (FireCoords(coordsRight))
                coordsToFire.Add(coordsRight);

            return coordsToFire;

        }

        public bool FireCoords(Coords coords)
        {
            return Forest.CheckCellState(coords) == State.Tree && rand.NextDouble() <= FireProba;
        }

    }
}
