using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProblemSolving1;

namespace Battleship
{
    class Human : Player
    {
        ConsoleOptionsInterface turnMenu;
        ConsoleOptionsInterface orientationMenu;
        public Human(string name, BattleConsole battleConsole)
        {
            this.name = name;
            this.battleConsole = battleConsole;
         
        }


        public override void SetBoard()
        {
            foreach (Ship ship in battleConsole.ownedShips)
            {
                DisplayOwnBoard();
                SetShip(ship);
            }
        }

        public void SetShip(Ship ship)
        {
            Console.WriteLine("Choose a space for one end of your " + ship.name + " of size " + ship.length + ". (eg. B:13)");
            List<int> coords;
            do {
                string coord = Console.ReadLine();
                coords = ConvertCoord(coord);
            } while (!ValidCoord(coords));
            Console.WriteLine("Choose an orientation");
            List<string> orientationOptions = new List<string> { "Up", "Down", "Left", "Right" };
            orientationMenu = new ConsoleOptionsInterface(orientationOptions, false, false);
            int optionSelected;
            do
            {
                optionSelected = orientationMenu.Launch();
            } while (!ValidPlacement(coords, optionSelected, ship));
        }

        public List<int> ConvertCoord(string coord)
        {
            string[] splitString = coord.Split(':');
            int column = int.Parse(splitString[1]);
            char row = Convert.ToChar(splitString[0]);
            List<int> coords = new List<int> { row, column };
            return coords;
        }

        public bool ValidCoord(List<int> coords)
        {
            if (battleConsole.ownedBoard[coords[0], coords[1]] != 79)
            {
                return false;
            }
            return true;
        }

        public bool ValidPlacement(List<int> coords, int optionSelected, Ship ship)
        {
            int increment;
            List<int> prospectiveCoords = new List<int> { coords[0], coords[1] };
            if (optionSelected == 1 || optionSelected == 3) { //if 'up' or 'left' selected, i will be decremented
                increment = -1;
            }
            else {//if 'down' or 'right' selected, i will be intcremented
                increment = 1;
            }
            if (optionSelected == 1 || optionSelected == 2) { //if 'up' or 'down', search through different rows at same column.
                for (int i = coords[0]; i < (coords[0] + ship.length * increment); i += increment)
                {
                    prospectiveCoords[0] = i;
                    if (!ValidCoord(prospectiveCoords)) {
                        return false;
                    }
                }
            }
            else  {//if 'left' or 'right', search through different columns at the given row.
                for (int i = coords[1]; i < (coords[1] + ship.length * increment); i += increment)
                {
                    prospectiveCoords[1] = i;
                    if (!ValidCoord(prospectiveCoords)) {
                        return false;
                    }
                }
            }
            return true;
        }


        public override void OptionsMenu()
        {
            List<string> turnOptions = new List<string> { "View Your Board", "View Opponent's Board", "Fire a Missile" };
            turnMenu = new ConsoleOptionsInterface(turnOptions, false, false);
            int optionSelected = turnMenu.Launch();
            
        }

        public override void SelectTargetCoord()
        {
            
        }

        public void DisplayOwnBoard()
        {

        }

        public void DisplayOpponentBoard()
        {

        }

        public void FireMissile()
        {

        }

    }
}
