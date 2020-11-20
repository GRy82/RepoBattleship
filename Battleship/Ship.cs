using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Ship
    {
        public string name;
        public int length;
        public Coordinates edgeOne;
        public Coordinates edgeTwo;
        public List<Coordinates> coordsList;
        public char symbolOne;
        public char symbolTwo;
        public Ship(string name, int length)
        {
            this.name = name;
            this.length = length;
            this.edgeOne = new Coordinates('\0', 0);
            this.edgeTwo = new Coordinates('\0', 0);
            this.coordsList = new List<Coordinates> { };
        }

        
    
    }
}
