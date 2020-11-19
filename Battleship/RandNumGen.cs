using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public static class RandNumGen
    {
        public static int GenerateRand(int lowerBound, int upperBound)
        {
            Random rand = new Random();
            int randomNum = rand.Next(lowerBound, upperBound);
            return randomNum;
        }
    }
}
