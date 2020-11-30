using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Computer : Player
    {

        public Computer(string name, BattleConsole battleConsole)
        {
            this.name = name;
            this.battleConsole = battleConsole;
        }


        public override void SetBoard()
        {
            base.SetBoard();
        }

        public override int[] GetFirstCoord(string name, int shipLength)
        {
            int rowIndex;
            int columnIndex;
            do
            {
                rowIndex = RandNumGen.GenerateRand(0, 20);
                columnIndex = RandNumGen.GenerateRand(0, 20);
            } while (!FirstCoordinateValidation(rowIndex, columnIndex, shipLength));

            int[] firstCoordinates = new int[2] { rowIndex, columnIndex };
            return firstCoordinates;
        }

        public override int GetCorrespondingOrientationNum(int[] firstCoordinate)
        {
            int randomOrientationNumber = RandNumGen.GenerateRand(1, 5);
            return randomOrientationNumber;
        }
    }
}
