using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Models
{
    public class Box : ObservableObject
    {
        public int Value { get; }

        public int ID { get; }

        public Box(int id, int value)
        {
            ID = id;
            Value = value;
        }
    }
}
