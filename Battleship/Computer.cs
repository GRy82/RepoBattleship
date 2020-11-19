using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Computer : Player
    {

        public Computer(string name, BattleConsole battleConsole)
        {
            this.name = name;
            this.battleConsole = battleConsole;
        }

        public override void SetBoard()
        {
            foreach (Ship ship in battleConsole.ownedShips)
            {
                SetShip(ship);
            }
            Console.WriteLine(name + "'s ships have been placed on their board");
        }

        public void SetShip(Ship ship)
        {
            Coordinates startingCoords = GetStartingCoordinate();
            int orientation = GetOrientation(startingCoords, ship);
            AssignAnchorPointsToShip(orientation, startingCoords, ship);
        }

        public override Coordinates GetStartingCoordinate()
        {
            string stringCoord;
            do
            {
                int numericRow = RandNumGen.GenerateRand(1, 21);
                int numericColumn = RandNumGen.GenerateRand(1, 21);
                stringCoord = Convert.ToChar(numericRow + 64) + ":" + numericColumn;
            } while (!Coordinates.ValidCoord(stringCoord));
            return Coordinates.ConvertCoord(stringCoord);
        }


        public override int GetOrientation(Coordinates coords, Ship ship)
        {
            int randomDirection;
            do
            {
                randomDirection = RandNumGen.GenerateRand(1, 5);

            } while (!CheckFit(coords, randomDirection, ship) || !CheckInterference(coords, randomDirection, ship));
            return randomDirection;
        }


        public override void OptionsMenu()
        {
            
        }
        public override void SelectTargetCoord()
        {

        }
    }
}
