using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wildfire.Entities
{
    public class Config
    {
        public int Height { get; set; }
        public int Length { get; set; }
        public double FireProba { get; set; }
        public List<Coords> FireCells { get; set; }

    }
}
