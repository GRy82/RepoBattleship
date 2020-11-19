using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Ship
    {
        public string name;
        public int length;
        public Coordinates edgeOne;
        public Coordinates edgeTwo;
        public char symbolOne;
        public char symbolTwo;
        public Ship(string name, int length)
        {
            this.name = name;
            this.length = length;
        }

        
    
    }
}
