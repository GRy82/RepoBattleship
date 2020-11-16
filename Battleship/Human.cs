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
            int optionSelected = orientationMenu.Launch();
            ValidPlacement(coords);
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
            return true;
        }

        public bool ValidPlacement(List<int> coords)
        {
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
