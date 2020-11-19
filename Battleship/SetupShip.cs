using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProblemSolving1;

namespace Battleship
{
    class SetupShip
    {
        BattleConsole battleConsole;

        public SetupShip(BattleConsole battleConsole)
        {
            this.battleConsole = battleConsole;
         
        }

        ConsoleOptionsInterface orientationMenu;
        public void SetShip(Ship ship)
        {
            Console.WriteLine("Choose a space for one end of your " + ship.name + " of size " + ship.length + ". (eg. B:13)");
            Coordinates coords = GetStartingCoordinate();
            Console.WriteLine("Choose an orientation");
            string orientationSelection = GetOrientation(coords, ship);
            AssignAnchorPointsToShip(ship, orientationSelection, coords);
        }

        void AssignAnchorPointsToShip(Ship ship, string orientation, Coordinates startingCoordinates)
        {
            ship.edgeOne.Row = startingCoordinates.Row;
            ship.edgeOne.Column = startingCoordinates.Column;

        }

        Coordinates GetStartingCoordinate()
        {
            string userInput;
            Coordinates coords = new Coordinates();
            do {
                do {
                    userInput = Console.ReadLine();
                } while (!coords.ValidCoord(userInput));
                coords = coords.ConvertCoord(userInput);
            } while (!AvailableCoord(coords));
            return coords;   
        }

        string GetOrientation(Coordinates coords, Ship ship)
        {
            List<string> orientationOptions = new List<string> { "Up", "Down", "Left", "Right" };
            orientationMenu = new ConsoleOptionsInterface(orientationOptions, false, false);
            int optionSelected;
            do
            {
                optionSelected = orientationMenu.Launch();
            } while (!ValidPlacement(coords, optionSelected, ship));

            return orientationOptions[optionSelected-1];//optionSelected is the number option entered. That - 1 is the index of the word chosen in the list.
        }


        bool AvailableCoord(Coordinates coords)
        {
            if (battleConsole.ownedBoard[coords.Row, coords.Column] != 79)
            {
                Console.WriteLine("\nShip cannot be placed there.");
                return false;
            }
            return true;
        }

        bool ValidPlacement(Coordinates coords, int optionSelected, Ship ship)
        {
            int increment;
            List<int> numericalCoords = new List<int> { (coords.Row - 65 + 1), coords.Column }; //-65 to align with numbers, + 1 to set it to second row(1st row is a table header)
            List<int> prospectiveCoords = numericalCoords;
            if (optionSelected == 1 || optionSelected == 3)
            { //if 'up' or 'left' selected, 'i' in future for-loop will be decremented
                increment = -1;
            }
            else
            {//if 'down' or 'right' selected, 'i' in future for-loop will be incremented
                increment = 1;
            }
            if (optionSelected == 1 || optionSelected == 2)
            { //if 'up' or 'down', search through different rows at same column.
                for (int i = numericalCoords[0]; i < (numericalCoords[0] + ship.length * increment); i += increment)
                {
                    prospectiveCoords[0] = i;
                    if (!AvailableCoord(coords.ConvertCoord(prospectiveCoords)))
                    {
                        return false;
                    }
                }
            }
            else
            {//if 'left' or 'right', search through different columns at the given row.
                for (int i = numericalCoords[1]; i < (numericalCoords[1] + ship.length * increment); i += increment)
                {
                    prospectiveCoords[1] = i;
                    if (!AvailableCoord(coords.ConvertCoord(prospectiveCoords)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
