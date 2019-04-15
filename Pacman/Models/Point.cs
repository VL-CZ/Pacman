using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Models
{
    public struct Point
    {
        public int Coord1 { get; set; }
        public int Coord2 { get; set; }

        public Point(int coord1, int coord2)
        {
            Coord1 = coord1;
            Coord2 = coord2;
        }

    }
}
