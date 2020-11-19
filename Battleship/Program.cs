using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            string poop = "poop::poop";
            string[] listofStrings = poop.Split(':');
            Console.WriteLine(listofStrings[1]);
            Console.ReadLine();
            Game battleship = new Game();
            battleship.Run();
        }
    }
}
