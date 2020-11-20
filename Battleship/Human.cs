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
            Coordinates coords = GetStartingCoordinate();
            Console.WriteLine("Choose an orientation");
            int orientationSelection = GetOrientation(coords, ship);
            AssignAnchorPointsToShip(orientationSelection, coords, ship);
        }

        public override Coordinates GetStartingCoordinate()
        {
            Coordinates coords;
            string userInput;
            do
            {
                do
                {
                    userInput = Console.ReadLine();
                } while (!Coordinates.ValidCoord(userInput));
                coords = Coordinates.ConvertCoord(userInput);
            } while (!Coordinates.CheckCoord(battleConsole, coords));
            return coords;
        }

        public override int GetOrientation(Coordinates coords, Ship ship)
        {
            List<string> orientationOptions = new List<string> { "Up", "Down", "Left", "Right" };
            ConsoleOptionsInterface orientationMenu = new ConsoleOptionsInterface(orientationOptions, false, false);
            int optionSelected;
            do
            {
                optionSelected = orientationMenu.Launch();
            } while (!CheckFit(coords, optionSelected, ship) || !CheckInterference(coords, optionSelected, ship));

            return optionSelected;
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
            for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 21; j++)
                {
                    Console.Write(Convert.ToChar(battleConsole.ownedBoard[i, j]) + " ");
                }
                Console.WriteLine();
            }
        }

        public void DisplayOpponentBoard()
        {

        }

        public void FireMissile()
        {

        }

    }
}
